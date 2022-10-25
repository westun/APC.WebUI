using APC.DAL.Repositories;
using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetProductCategoriesAsync()
        {
            var categories = await this.productCategoryRepository.GetAsync();

            return categories.Select(c => new ProductCategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
