using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<IEnumerable<ProductDTO>> GetAllProductsByAccountIdAsync(int accountId);
        Task<IEnumerable<ProductDTO>> Search(string criteria);
        Task<ProductDTO> Save(ProductDTO productDTO);
    }
}