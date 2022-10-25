using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);
        Task<IEnumerable<Product>> GetAsync();
        Task<IEnumerable<Product>> Search(string criteria);
        Task<Product> Save(Product product);
    }
}