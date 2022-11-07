using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public ProductRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<Product> GetAsync(int id)
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();
            return await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Type)
                .Include(p => p.ProductAttributesValues)
                .ThenInclude(pav => pav.ProductAttribute)
                .Include(p => p.AreasOfApplications)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetAsync(int productId, int accountId)
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();
            return await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Type)
                .Include(p => p.ProductAttributesValues)
                .ThenInclude(pav => pav.ProductAttribute)
                .Include(p => p.AreasOfApplications)
                .Include(p => p.AccountProduct.Where(ap => ap.AccountId == accountId))
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();
            return await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Type)
                .OrderBy(p => p.Type.Name)
                .ThenBy(p => p.Name)
                .Include(p => p.AreasOfApplications)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByAccountIdAsync(int accountId)
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();

            var accountProducts = dbContext.AccountProduct.Where(p => p.AccountId == accountId);
            var apProductIds = accountProducts.Select(ap => ap.ProductId);
            
            var account = dbContext.Account
                .Include(a => a.Companies)
                .FirstOrDefault(a => a.Id == accountId);
            var companyIds = account.Companies.Select(c => c.Id).ToList();

            //if the user won't see any products, show them all APC products
            var companies = dbContext.Company.ToList();
            if (!apProductIds.Any() && !companyIds.Any())
            {
                var apc = companies.FirstOrDefault(c => c.Name == "American Paper Converting");
                if (apc is not null)
                {
                    companyIds.Add(apc.Id);
                }
            }
                
            return await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Type)
                .OrderBy(p => p.Type.Name)
                .ThenBy(p => p.Name)
                .Include(p => p.AreasOfApplications)
                .Include(p => p.AccountProduct.Where(ap => ap.AccountId == accountId))
                //filter products by products the customer is assigned to or if they are assigned a company(s) show all the companie's products
                .Where(p => (apProductIds.Contains(p.Id) || companyIds.Contains(p.CompanyId)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync(string criteria)
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();

            if (string.IsNullOrWhiteSpace(criteria))
            {
                return await this.GetAsync();
            }

            var allProducts = await this.GetAsync();
            
            return allProducts.Where(p => p.Name.ToLower().Contains(criteria.ToLower()));
        }

        public async Task<Product> SaveAsync(Product product)
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();
            var addingNewProduct = product.Id <= 0;
            if (addingNewProduct)
            {
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();

                return product;
            }

            //get entity from dbContext, edit it, then save changes to change existing data
            var existingProduct = dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct is null)
            {
                throw new ArgumentOutOfRangeException(nameof(existingProduct.Id));
            }

            //https://stackoverflow.com/questions/46657813/how-to-update-record-using-entity-framework-core
            existingProduct.Name = product.Name;
            existingProduct.DisplayName = product.DisplayName;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.TypeId = product.TypeId;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.Recycled = product.Recycled;
            existingProduct.BrochureUrl = product.BrochureUrl;
            existingProduct.CompanyId = product.CompanyId;

            await dbContext.SaveChangesAsync();

            return product;
        }
    }
}
