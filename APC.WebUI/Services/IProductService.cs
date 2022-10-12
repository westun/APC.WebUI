using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    }
}