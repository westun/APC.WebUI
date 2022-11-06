using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IAccountProductRepository
    {
        Task<IEnumerable<AccountProduct>> GetAsync(int accountId);
        Task Add(AccountProduct accountProduct);
        Task Remove(AccountProduct accountProduct);
    }
}