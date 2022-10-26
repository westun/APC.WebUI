using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IProductAttributeRepository productAttributeRepository;
        private readonly IMapper mapper;

        public ProductAttributeService(
            IProductAttributeRepository productAttributeRepository,
            IMapper mapper)
        {
            this.productAttributeRepository = productAttributeRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductAttributeDTO>> GetProductAttributesAsync()
        {
            var atttributes = await this.productAttributeRepository.GetAsync();

            return atttributes.Select(c => new ProductAttributeDTO
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<ProductAttributeDTO> SaveProductAttributeAsync(ProductAttributeDTO productAttributeDTO)
        {
            var attribute = this.mapper.Map<ProductAttribute>(productAttributeDTO);

            var attributeFromDB = await this.productAttributeRepository.SaveAsync(attribute);

            return this.mapper.Map<ProductAttributeDTO>(attributeFromDB);
        }
    }
}
