using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class CartProductService : ICartProductService
    {
        private readonly ICartProductRepository cartProductRepository;
        private readonly IMapper mapper;

        public CartProductService(
            ICartProductRepository cartProductRepository,
            IMapper mapper)
        {
            this.cartProductRepository = cartProductRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(CartProductDTO cartProductDTO)
        {
            var cartProduct = this.mapper.Map<CartProduct>(cartProductDTO);

            await this.cartProductRepository.AddAsync(cartProduct);
        }

        public async Task DeleteAsync(CartProductDTO cartProductDTO)
        {
            var cartProduct = this.mapper.Map<CartProduct>(cartProductDTO);

            await this.cartProductRepository.DeleteAsync(cartProduct);
        }
    }
}
