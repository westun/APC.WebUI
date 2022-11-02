using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface ICartService
    {
        Task<CartDTO> GetCartAsync(int accountId);
        Task CompleteCartAsync(int cartId);
        Task CreateCartAsync(CartDTO cartDTO);
    }
}