using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountAsync(string OID);
    }
}