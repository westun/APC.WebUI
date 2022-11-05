using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;

        public AccountService(
            IAccountRepository accountRepository,
            IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        public async Task<AccountDTO> GetAccountAsync(string OID)
        {
            var account = await this.accountRepository.GetAsync(OID);

            return this.mapper.Map<AccountDTO>(account);
        }

        public async Task<IEnumerable<AccountDTO>> GetAccountsAsync()
        {
            var accounts = await this.accountRepository.GetAsync();

            return this.mapper.Map<IEnumerable<AccountDTO>>(accounts);
        }

        public async Task SaveCompaniesToAccountAsync(
            int accountId,
            IEnumerable<CompanyDTO> companyDTOs)
        {
            if (companyDTOs is null)
            {
                throw new ArgumentNullException(nameof(companyDTOs));
            }

            var companies =
                this.mapper.Map<IEnumerable<Company>>(companyDTOs);

            await this.accountRepository.SaveCompaniesAsync(accountId, companies);
        }
    }
}
