using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IProductAttributeRepository
    {
        Task<IEnumerable<ProductAttribute>> GetAsync();
        Task<ProductAttribute> SaveAsync(ProductAttribute productAttribute);
    }
}