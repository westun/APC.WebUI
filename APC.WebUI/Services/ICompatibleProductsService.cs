using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface ICompatibleProductsService
    {
        Task DeleteAsync(CompatibleProductsDTO compatibleProductsDTO);
        Task<IEnumerable<CompatibleProductsDTO>> GetCompatibleProductsByProductIdAsync(int productId);
        Task SaveAsync(CompatibleProductsDTO compatibleProductsDTO);
    }
}