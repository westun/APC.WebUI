using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public ProductCategoryRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<ProductCategory>> GetAsync()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.ProductCategories.ToListAsync();
        }
    }
}
