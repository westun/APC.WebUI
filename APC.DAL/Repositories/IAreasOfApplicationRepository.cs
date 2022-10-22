using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IAreasOfApplicationRepository
    {
        Task<IEnumerable<AreasOfApplication>> GetAsync();
        Task Save(int productId, IEnumerable<AreasOfApplication> areasOfApplications);
    }
}