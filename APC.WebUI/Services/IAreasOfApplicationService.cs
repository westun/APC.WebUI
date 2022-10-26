using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IAreasOfApplicationService
    {
        Task<IEnumerable<AreasOfApplicationDTO>> GetAreasOfApplicationAsync();
        Task SaveProductAreasOfApplicationAsync(int productId, IEnumerable<AreasOfApplicationDTO> areasOfApplicationDTOs);
        Task<AreasOfApplicationDTO> SaveAreasOfApplicationAsync(AreasOfApplicationDTO areasOfApplicationDTO);

    }
}