using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface ICartProductRepository
    {
        Task AddAsync(CartProduct cartProduct);
    }
}