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

            await dbContext.SaveChangesAsync();

            return product;
        }
    }
}
