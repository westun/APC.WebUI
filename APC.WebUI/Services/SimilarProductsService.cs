using APC.DAL.Repositories;
using APC.WebUI.Models;
using APC.WebUI.Pages.Admin;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class SimilarProductsService : ISimilarProductsService
    {
        private readonly ISimilarProductsRepository similarProductsRepository;
        private readonly IMapper mapper;

        public SimilarProductsService(
            ISimilarProductsRepository similarProductsRepository,
            IMapper mapper)
        {
            this.similarProductsRepository = similarProductsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SimilarProductsDTO>> GetSimilarProductsByProductIdAsync(int productId)
        {
            var similarProducts = await this.similarProductsRepository.GetAsync(productId);

            return similarProducts.Select(c => new SimilarProductsDTO
            {
                TheProductid = c.TheProductid,
                SimiliarProduct = c.SimilarProduct,
                SimilarProductId = c.SimilarProductId,
                TheProduct = c.TheProduct,
            });
        }

        public async Task SaveAsync(SimilarProductsDTO similarProductsDTO)
        {
            var similarProduct = this.mapper.Map<APC.DAL.Models.SimilarProducts>(similarProductsDTO);

            await this.similarProductsRepository.SaveAsync(similarProduct);
        }

        public async Task DeleteAsync(SimilarProductsDTO similarProductsDTO)
        {
            var similarProduct = this.mapper.Map<APC.DAL.Models.SimilarProducts>(similarProductsDTO);

            await this.similarProductsRepository.DeleteAsync(similarProduct);
        }
    }
}
