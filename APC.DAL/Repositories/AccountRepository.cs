using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public AccountRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<Account> GetAsync(string OID)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return dbContext.Account
                .FirstOrDefault(c => c.ObjectIdentifier == OID);
        }
    }
}
