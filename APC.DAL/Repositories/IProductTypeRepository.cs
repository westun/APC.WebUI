using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAsync();
        Task<ProductType> SaveAsync(ProductType productType);
    }
}