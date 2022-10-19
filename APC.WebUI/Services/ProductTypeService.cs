using APC.DAL.Repositories;
using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            this.productTypeRepository = productTypeRepository;
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
    }
}
