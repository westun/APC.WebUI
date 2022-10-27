using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class CompatibleProductsRepository : ICompatibleProductsRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public CompatibleProductsRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<CompatibleProducts>> GetAsync(int productId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext.CompatibleProducts
                .Where(sp => sp.TheProductid == productId)
                .Include(sp => sp.CompatibleProduct)
                    .ThenInclude(sp => sp.Type)
                .Include(sp => sp.TheProduct)
                .ToListAsync();
        }

        public async Task SaveAsync(CompatibleProducts compatibleProduct)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var compatibleProductFromDB = dbContext.CompatibleProducts
                .FirstOrDefault(sp =>
                    sp.CompatibleProductId == compatibleProduct.CompatibleProductId
                    && sp.TheProductid == compatibleProduct.TheProductid);
            if (compatibleProductFromDB is null)
            {
                dbContext.CompatibleProducts.Add(compatibleProduct);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(CompatibleProducts compatibleProduct)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var compatibleProductFromDB = dbContext.CompatibleProducts
                .FirstOrDefault(sp =>
                    sp.CompatibleProductId == compatibleProduct.CompatibleProductId
                    && sp.TheProductid == compatibleProduct.TheProductid);
            if (compatibleProductFromDB is not null)
            {
                dbContext.CompatibleProducts.Remove(compatibleProductFromDB);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
