using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(string OID);
        Task<Account> GetAsync(int accountId);
        Task<IEnumerable<Account>> GetAsync();
        Task SaveAccount(Account account);
        Task SaveCompaniesAsync(int accountId, IEnumerable<Company> companies);
    }
}