using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IAreasOfApplicationRepository
    {
        Task<IEnumerable<AreasOfApplication>> GetAsync();
        Task SaveAsync(int productId, IEnumerable<AreasOfApplication> areasOfApplications);
        Task<AreasOfApplication> SaveAsync(AreasOfApplication areasOfApplication);
    }
}