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
                .ToListAsync();
        }

        public async Task<Product> Save(Product product)
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return product;
        }
    }
}
