using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IProductAttributeValueRepository
    {
        Task SaveAsync(int productId, IEnumerable<ProductAttributeValue> productAttributeValues);
    }
}