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
                .Include(c => c.Account)
                .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                        .ThenInclude(p => p.Type)
                .FirstOrDefault(c => c.AccountId == accountId && !c.Completed);
        }

        public async Task CompleteCartAsync(int cartId)
        {
            var dbContext = await dbContextFactory.CreateDbContextAsync();

            var cartFromDB = dbContext.Cart.FirstOrDefault(c => c.Id == cartId);
            if (cartFromDB is not null)
            {
                cartFromDB.Completed = true;
                dbContext.SaveChanges();
            }
        }
    }
}
