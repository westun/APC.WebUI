using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface ISimilarProductsService
    {
        Task<IEnumerable<SimilarProductsDTO>> GetSimilarProductsByProductIdAsync(int productId);
        Task SaveAsync(SimilarProductsDTO similarProductsDTO);
        Task DeleteAsync(SimilarProductsDTO similarProductsDTO);
    }
}