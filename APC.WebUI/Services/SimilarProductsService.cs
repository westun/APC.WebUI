using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;
using System.Collections.Generic;

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

            return this.mapper.Map<IEnumerable<SimilarProductsDTO>>(similarProducts);
        }

        public async Task SaveAsync(SimilarProductsDTO similarProductsDTO)
        {
            var similarProduct = this.mapper.Map<SimilarProducts>(similarProductsDTO);

            await this.similarProductsRepository.SaveAsync(similarProduct);
        }

        public async Task DeleteAsync(SimilarProductsDTO similarProductsDTO)
        {
            var similarProduct = this.mapper.Map<SimilarProducts>(similarProductsDTO);

            await this.similarProductsRepository.DeleteAsync(similarProduct);
        }
    }
}
