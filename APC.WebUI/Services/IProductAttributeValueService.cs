using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IProductAttributeValueService
    {
        Task SaveProductAttributeValues(int productId, IEnumerable<ProductAttributeValueDTO> productAttributeValueDTOs);
    }
}