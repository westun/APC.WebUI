using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAsync();
    }
}