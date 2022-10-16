using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await this.productRepository.GetAsync(id);

            return this.mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await this.productRepository.GetAsync();

            return products.Select(p => this.mapper.Map<ProductDTO>(p));
        }

        public async Task<ProductDTO> Save(ProductDTO productDTO)
        {
            if (productDTO is null)
            {
                throw new ArgumentNullException(nameof(productDTO));
            }

            var product = this.mapper.Map<Product>(productDTO);

            var productSavedFromDB = await this.productRepository.Save(product);

            return this.mapper.Map<ProductDTO>(productSavedFromDB);
        }
    }
}
