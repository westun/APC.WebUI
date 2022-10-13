using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

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
                CategoryId = product.CategoryId,
                TypeId = product.TypeId,
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
                CategoryId = p.CategoryId,
                TypeId = p.TypeId,
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

        public async Task<ProductDTO> Save(ProductDTO productDTO)
        {
            if (productDTO is null)
            {
                throw new ArgumentNullException(nameof(productDTO));
            }

            var product = new Product
            {
                Id = productDTO.Id,
                CategoryId = productDTO.CategoryId,
                TypeId = productDTO.TypeId,
                Name = productDTO.Name,
                Description = productDTO.Description,
                ImageUrl = productDTO.ImageUrl,
            };

            var productSavedFromDB = await this.productRepository.Save(product);

            return new ProductDTO
            {
                Id = productSavedFromDB.Id,
                Name = productSavedFromDB.Name,
                Description = productSavedFromDB.Description,
                ImageUrl = productSavedFromDB.ImageUrl,
                Category = new ProductCategoryDTO
                {
                    Name = productSavedFromDB?.Category?.Name,
                },
                Type = new ProductTypeDTO
                {
                    Name = productSavedFromDB?.Type?.Name,
                },
                AttributeValues = productSavedFromDB.ProductAttributesValues.Select(pav => new ProductAttributeValueDTO()
                {
                    Value = pav.Value,
                    DisplayOrder = pav.DisplayOrder,
                    Attribute = new ProductAttributeDTO
                    {
                        Name = pav.ProductAttribute.Name,
                    }
                }),
                AreasOfApplications = productSavedFromDB.AreasOfApplications.Select(aoa => new AreasOfApplicationDTO
                {
                    Name = aoa.Name,
                }),
            };
        }
    }
}
