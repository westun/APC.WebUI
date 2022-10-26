using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IProductAttributeService
    {
        Task<IEnumerable<ProductAttributeDTO>> GetProductAttributesAsync();
        Task<ProductAttributeDTO> SaveProductAttributeAsync(ProductAttributeDTO productAttributeDTO);
    }
}