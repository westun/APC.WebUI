using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface ISimilarProductsRepository
    {
        Task<IEnumerable<SimilarProducts>> GetAsync(int productId);
    }
}