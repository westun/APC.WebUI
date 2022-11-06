using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IAccountProductRepository
    {
        Task<IEnumerable<AccountProduct>> GetAsync(int accountId);
        Task AddAsync(AccountProduct accountProduct);
        Task UpdateAsync(AccountProduct accountProduct);
        Task RemoveAsync(AccountProduct accountProduct);
    }
}