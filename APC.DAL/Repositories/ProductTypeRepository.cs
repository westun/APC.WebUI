using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public ProductTypeRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<ProductType>> GetAsync()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.ProductTypes
                .Include(pt => pt.Category)
                .ToListAsync();
        }
    }
}
