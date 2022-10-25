using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAsync();
    }
}