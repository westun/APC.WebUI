using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public CartRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<Cart> GetAsync(int accountId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return dbContext.Cart
                .FirstOrDefault(c => c.Id == accountId && !c.Completed);
        }
    }
}
