using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(string OID);
        Task<IEnumerable<Account>> GetAsync();
        Task SaveCompaniesAsync(int accountId, IEnumerable<Company> companies);
    }
}