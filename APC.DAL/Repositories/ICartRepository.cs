using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetAsync(int accountId);
    }
}