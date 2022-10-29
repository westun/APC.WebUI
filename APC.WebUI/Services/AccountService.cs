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
    }
}
