﻿using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        private readonly IMapper mapper;

        public CartService(
            ICartRepository cartRepository,
            IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.mapper = mapper;
        }

        public async Task<CartDTO> GetCartAsync(int accountId)
        {
            var cart = await this.cartRepository.GetAsync(accountId);

            return this.mapper.Map<CartDTO>(cart);
        }
    }
}