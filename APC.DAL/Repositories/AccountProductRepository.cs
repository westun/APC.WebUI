using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class AccountProductRepository : IAccountProductRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public AccountProductRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<AccountProduct>> GetAsync(int accountId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return dbContext.AccountProduct
                .Include(ap => ap.Product)
                .Where(ap => ap.AccountId == accountId)
                .ToList();
        }

        public async Task Add(AccountProduct accountProduct)
        {
            if (accountProduct is null)
            {
                throw new ArgumentNullException(nameof(accountProduct));
            }

            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            dbContext.Add(accountProduct);
            await dbContext.SaveChangesAsync();
        }
    }
}
