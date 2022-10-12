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

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await this.productRepository.GetAsync(id);

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Category = new ProductCategoryDTO
                {
                    Name = product.Category.Name,
                },
                Type = new ProductTypeDTO
                {
                    Name = product.Type.Name,
                },
                AttributeValues = product.ProductAttributesValues.Select(pav => new ProductAttributeValueDTO()
                {
                    Value = pav.Value,
                    DisplayOrder = pav.DisplayOrder,
                    Attribute = new ProductAttributeDTO
                    {
                        Name = pav.ProductAttribute.Name,
                    }
                }),
                AreasOfApplications = product.AreasOfApplications.Select(aoa => new AreasOfApplicationDTO
                {
                    Name = aoa.Name,
                }),
            };
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
