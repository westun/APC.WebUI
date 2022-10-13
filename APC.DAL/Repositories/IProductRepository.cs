using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> Save(Product product);
    }
}