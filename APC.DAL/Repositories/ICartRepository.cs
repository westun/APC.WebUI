using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetAsync(int accountId);
        Task CompleteCartAsync(int cartId);
        Task CreateAsync(Cart cart);
    }
}