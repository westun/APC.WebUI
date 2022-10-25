using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IMapper mapper;

        public ProductTypeService(
            IProductTypeRepository productTypeRepository,
            IMapper mapper)
        {
            this.productTypeRepository = productTypeRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductTypeDTO>> GetProductTypesAsync()
        {
            var categories = await this.productTypeRepository.GetAsync();

            return categories.Select(c => new ProductTypeDTO
            {
                Id = c.Id,
                Name = c.Name,
                CategoryId = c.CategoryId,
                Category = new ProductCategoryDTO
                {
                    Id = c.Category.Id,
                    Name = c.Category.Name,
                }
            });
        }

        public async Task<ProductTypeDTO> SaveProductType(ProductTypeDTO productTypeDTO)
        {
            var productType = this.mapper.Map<ProductType>(productTypeDTO);

            var productTypeFromDB = await this.productTypeRepository.Save(productType);

            return this.mapper.Map<ProductTypeDTO>(productTypeFromDB);
        }
    }
}
