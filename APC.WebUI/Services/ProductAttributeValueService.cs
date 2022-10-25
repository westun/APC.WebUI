using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class ProductAttributeValueService : IProductAttributeValueService
    {
        private readonly IProductAttributeValueRepository productAttributeValueRepository;
        private readonly IMapper mapper;

        public ProductAttributeValueService(
            IProductAttributeValueRepository productAttributeValueRepository,
            IMapper mapper)
        {
            this.productAttributeValueRepository = productAttributeValueRepository;
            this.mapper = mapper;
        }

        public async Task SaveProductAttributeValues(int productId, IEnumerable<ProductAttributeValueDTO> productAttributeValueDTOs)
        {
            var pav = this.mapper.Map<IEnumerable<ProductAttributeValue>>(productAttributeValueDTOs);

            await this.productAttributeValueRepository.Save(productId, pav);
        }
    }
}
