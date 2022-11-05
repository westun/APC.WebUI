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

        public async Task<IEnumerable<Account>> GetAsync()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return dbContext.Account
                .Include(a => a.Companies)
                .ToList();
        }

        public async Task SaveCompaniesAsync(int accountId, IEnumerable<Company> companies)
        {
            if (companies is null)
            {
                throw new ArgumentNullException(nameof(companies));
            }

            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();

            var account = dbContext.Account
                .Include(a => a.Companies)
                .FirstOrDefault(a => a.Id == accountId);
            if (account is null)
            {
                throw new Exception("Account not found by Id");
            }

            var dbIds = account.Companies.Select(a => a.Id).ToArray();
            var selectedIds = companies.Select(a => a.Id).ToArray();
            var ignoreIntersectIds = dbIds.Intersect(selectedIds).ToArray();

            var removeExceptIds = dbIds.Except(selectedIds).ToArray();
            foreach (var cId in removeExceptIds)
            {
                var companyToRemove = account.Companies.FirstOrDefault(c => c.Id == cId);
                account.Companies.Remove(companyToRemove);
            }

            var addExceptIds = selectedIds.Except(dbIds).ToArray();
            foreach (var cID in addExceptIds)
            {
                var companyToAdd = companies.FirstOrDefault(c => c.Id == cID);
                account.Companies.Add(companyToAdd);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
