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

        public async Task<Company> SaveAsync(Company company)
        {
            if (company is null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var companyFromDB = dbContext.Company.FirstOrDefault(c => c.Id == company.Id);
            if (companyFromDB is null)
            {
                dbContext.Add(company);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                companyFromDB = company;
                await dbContext.SaveChangesAsync();
            }

            return company;
        }
    }
}
