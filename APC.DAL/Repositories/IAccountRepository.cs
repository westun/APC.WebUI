using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(string OID);
    }
}