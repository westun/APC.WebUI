using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoryDTO>> GetProductCategoriesAsync();
    }
}