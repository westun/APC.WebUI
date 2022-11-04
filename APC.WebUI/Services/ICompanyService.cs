using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetCompaniesAsync();
    }
}