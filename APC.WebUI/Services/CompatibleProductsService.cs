using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class CompatibleProductsService : ICompatibleProductsService
    {
        private readonly ICompatibleProductsRepository compatibleProductsRepository;
        private readonly IMapper mapper;

        public CompatibleProductsService(
            ICompatibleProductsRepository compatibleProductsRepository,
            IMapper mapper)
        {
            this.compatibleProductsRepository = compatibleProductsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CompatibleProductsDTO>> GetCompatibleProductsByProductIdAsync(int productId)
        {
            var compatibleProducts = await this.compatibleProductsRepository.GetAsync(productId);

            return this.mapper.Map<IEnumerable<CompatibleProductsDTO>>(compatibleProducts);
        }

        public async Task SaveAsync(CompatibleProductsDTO compatibleProductsDTO)
        {
            var compatibleProduct = this.mapper.Map<APC.DAL.Models.CompatibleProducts>(compatibleProductsDTO);

            await this.compatibleProductsRepository.SaveAsync(compatibleProduct);
        }

        public async Task DeleteAsync(CompatibleProductsDTO compatibleProductsDTO)
        {
            var compatibleProduct = this.mapper.Map<APC.DAL.Models.CompatibleProducts>(compatibleProductsDTO);

            await this.compatibleProductsRepository.DeleteAsync(compatibleProduct);
        }
    }
}
