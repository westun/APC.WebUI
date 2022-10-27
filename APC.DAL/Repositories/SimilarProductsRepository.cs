using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class SimilarProductsRepository : ISimilarProductsRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public SimilarProductsRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<SimilarProducts>> GetAsync(int productId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext.SimilarProducts
                .Where(sp => sp.TheProductid == productId)
                .Include(sp => sp.SimilarProduct)
                    .ThenInclude(sp => sp.Type)
                .Include(sp => sp.TheProduct)
                .ToListAsync();
        }

        public async Task SaveAsync(SimilarProducts similarProduct)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var similiarProductFromDB = dbContext.SimilarProducts
                .FirstOrDefault(sp =>
                    sp.SimilarProductId == similarProduct.SimilarProductId
                    && sp.TheProductid == similarProduct.TheProductid);
            if (similiarProductFromDB is null)
            {
                dbContext.SimilarProducts.Add(similarProduct);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(SimilarProducts similarProduct)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var similiarProductFromDB = dbContext.SimilarProducts
                .FirstOrDefault(sp => 
                    sp.SimilarProductId == similarProduct.SimilarProductId
                    && sp.TheProductid == similarProduct.TheProductid);
            if (similiarProductFromDB is not null)
            {
                dbContext.SimilarProducts.Remove(similiarProductFromDB);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
