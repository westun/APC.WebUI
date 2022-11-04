using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IMapper mapper;

        public ProductCategoryService(
            IProductCategoryRepository productCategoryRepository,
            IMapper mapper)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetProductCategoriesAsync()
        {
            var categories = await this.productCategoryRepository.GetAsync();

            return this.mapper.Map<IEnumerable<ProductCategoryDTO>>(categories);
        }
    }
}
