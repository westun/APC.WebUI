using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class AccountProductService : IAccountProductService
    {
        private readonly IAccountProductRepository accountProductRepository;
        private readonly IMapper mapper;

        public AccountProductService(
            IAccountProductRepository accountProductRepository,
            IMapper mapper)
        {
            this.accountProductRepository = accountProductRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AccountProductDTO>> GetAccountProductsAsync(int accountId)
        {
            var accountProducts = await this.accountProductRepository.GetAsync(accountId);

            return this.mapper.Map<IEnumerable<AccountProductDTO>>(accountProducts);
        }

        public async Task AddAccountProductAsync(AccountProductDTO accountProductDTO)
        {
            var accountProduct = this.mapper.Map<AccountProduct>(accountProductDTO);

            await this.accountProductRepository.AddAsync(accountProduct);
        }

        public async Task UpdateAccountProductAsync(AccountProductDTO accountProductDTO)
        {
            var accountProduct = this.mapper.Map<AccountProduct>(accountProductDTO);

            await this.accountProductRepository.UpdateAsync(accountProduct);
        }

        public async Task RemoveAccountProductAsync(AccountProductDTO accountProductDTO)
        {
            var accountProduct = this.mapper.Map<AccountProduct>(accountProductDTO);

            await this.accountProductRepository.RemoveAsync(accountProduct);
        }
    }
}
