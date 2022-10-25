using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class AreasOfApplicationService : IAreasOfApplicationService
    {
        private readonly IAreasOfApplicationRepository areasOfApplicationRepository;
        private readonly IMapper mapper;

        public AreasOfApplicationService(
            IAreasOfApplicationRepository areasOfApplicationRepository,
            IMapper mapper)
        {
            this.areasOfApplicationRepository = areasOfApplicationRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AreasOfApplicationDTO>> GetAreasOfApplicationAsync()
        {
            var areasOfApplication = await this.areasOfApplicationRepository.GetAsync();

            return areasOfApplication.Select(c => new AreasOfApplicationDTO
            {
                Id = c.Id,
                Name = c.Name,
            });
        }

        public async Task SaveProductAreasOfApplication(
            int productId,
            IEnumerable<AreasOfApplicationDTO> areasOfApplicationDTOs)
        {
            if (areasOfApplicationDTOs is null)
            {
                throw new ArgumentNullException(nameof(areasOfApplicationDTOs));
            }

            var areasOfApplication =
                this.mapper.Map<IEnumerable<AreasOfApplication>>(areasOfApplicationDTOs);

            await this.areasOfApplicationRepository.Save(productId, areasOfApplication);
        }

        public async Task<AreasOfApplicationDTO> SaveAreasOfApplication(AreasOfApplicationDTO areasOfApplicationDTO)
        {
            var areasOfApplication =
                this.mapper.Map<AreasOfApplication>(areasOfApplicationDTO);

            var areasOfApplicationFromDB = 
                await this.areasOfApplicationRepository.Save(areasOfApplication);

            return this.mapper.Map<AreasOfApplicationDTO>(areasOfApplicationFromDB);
        }
    }
}
