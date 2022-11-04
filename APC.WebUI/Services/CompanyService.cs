using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public CompanyService(
            ICompanyRepository companyRepository,
            IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDTO>> GetCompaniesAsync()
        {
            var companies = await this.companyRepository.GetAsync();

            return this.mapper.Map<IEnumerable<CompanyDTO>>(companies);
        }
    }
}
