using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);
        Task<Product> GetAsync(int productId, int accountId);
        Task<IEnumerable<Product>> GetAsync();
        Task<IEnumerable<Product>> GetByAccountIdAsync(int accountId);
        Task<IEnumerable<Product>> SearchAsync(string criteria);
        Task<Product> SaveAsync(Product product);
    }
}