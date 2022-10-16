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
    }
}
