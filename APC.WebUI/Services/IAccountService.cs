using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountAsync(string OID);
        Task<IEnumerable<AccountDTO>> GetAccountsAsync();
        Task SaveCompaniesToAccountAsync(int accountId, IEnumerable<CompanyDTO> companyDTOs);
    }
}