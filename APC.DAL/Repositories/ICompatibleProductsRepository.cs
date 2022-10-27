using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface ICompatibleProductsRepository
    {
        Task DeleteAsync(CompatibleProducts compatibleProduct);
        Task<IEnumerable<CompatibleProducts>> GetAsync(int productId);
        Task SaveAsync(CompatibleProducts compatibleProduct);
    }
}