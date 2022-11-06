using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IAccountProductService
    {
        Task<IEnumerable<AccountProductDTO>> GetAccountProductsAsync(int accountId);
        Task AddAccountProduct(AccountProductDTO accountProductDTO);
        Task UpdateAccountProduct(AccountProductDTO accountProductDTO);
        Task RemoveAccountProduct(AccountProductDTO accountProductDTO);
    }
}