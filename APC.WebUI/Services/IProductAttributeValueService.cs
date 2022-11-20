using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IProductAttributeValueService
    {
        Task SaveProductAttributeValuesAsync(int productId, IEnumerable<ProductAttributeValueDTO> productAttributeValueDTOs);
        Task RemoveProductAttributeValueAsync(ProductAttributeValueDTO productAttributeValueDTO);
    }
}