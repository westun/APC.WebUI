using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public CompanyRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Company>> GetAsync()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext.Company.ToListAsync();
        }
    }
}
