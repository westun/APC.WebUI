using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IAccountProductService
    {
        Task<IEnumerable<AccountProductDTO>> GetAccountProductsAsync(int accountId);
        Task AddAccountProduct(AccountProductDTO accountProductDTO);
    }
}