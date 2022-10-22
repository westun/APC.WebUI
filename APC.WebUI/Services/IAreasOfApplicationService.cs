using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IAreasOfApplicationService
    {
        Task<IEnumerable<AreasOfApplicationDTO>> GetAreasOfApplicationAsync();
        Task SaveProductAreasOfApplication(int productId, IEnumerable<AreasOfApplicationDTO> areasOfApplicationDTOs);

    }
}