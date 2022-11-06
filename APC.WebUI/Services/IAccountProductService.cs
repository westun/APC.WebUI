using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IAccountProductService
    {
        Task<IEnumerable<AccountProductDTO>> GetAccountProductsAsync(int accountId);
        Task AddAccountProductAsync(AccountProductDTO accountProductDTO);
        Task UpdateAccountProductAsync(AccountProductDTO accountProductDTO);
        Task RemoveAccountProductAsync(AccountProductDTO accountProductDTO);
    }
}