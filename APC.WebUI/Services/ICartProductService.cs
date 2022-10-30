using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface ICartProductService
    {
        Task AddAsync(CartProductDTO cartProductDTO);
        Task DeleteAsync(CartProductDTO cartProductDTO);
    }
}