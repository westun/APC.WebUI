using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IProductAttributeValueRepository
    {
        Task Save(int productId, IEnumerable<ProductAttributeValue> productAttributeValues);
    }
}