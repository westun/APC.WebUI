using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountAsync(string OID);
        Task<AccountDTO> GetAccountAsync(int accountId);
        Task<IEnumerable<AccountDTO>> GetAccountsAsync();
        Task SaveAccount(AccountDTO accountDTO);
        Task SaveCompaniesToAccountAsync(int accountId, IEnumerable<CompanyDTO> companyDTOs);
    }
}