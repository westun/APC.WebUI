using APC.DAL.Repositories;
using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public class SimilarProductsService : ISimilarProductsService
    {
        private readonly ISimilarProductsRepository similarProductsRepository;

        public SimilarProductsService(ISimilarProductsRepository similarProductsRepository)
        {
            this.similarProductsRepository = similarProductsRepository;
        }

        public async Task<IEnumerable<SimilarProductsDTO>> GetSimilarProductsByProductIdAsync(int productId)
        {
            var similarProducts = await this.similarProductsRepository.GetAsync(productId);

            return similarProducts.Select(c => new SimilarProductsDTO
            {
                TheProductid = c.TheProductid,
                SimiliarProduct = c.SimilarProduct,
                SimiliarProductId = c.SimilarProductId,
                TheProduct = c.TheProduct,
            });
        }
    }
}
