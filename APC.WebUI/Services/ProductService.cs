using APC.DAL.Repositories;
using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await this.productRepository.GetAsync();

            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Category = new ProductCategoryDTO
                {
                    Name = p.Category.Name,
                },
                Type = new ProductTypeDTO
                {
                    Name = p.Type.Name,
                }
            });
        }
    }
}
