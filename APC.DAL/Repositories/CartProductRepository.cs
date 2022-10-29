﻿using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class CartProductRepository : ICartProductRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public CartProductRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task AddAsync(CartProduct cartProduct)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var cartProductFromDB = dbContext.CartProducts
                .FirstOrDefault(sp => sp.ProductId == cartProduct.ProductId
                    && sp.CartId == cartProduct.CartId);
            if (cartProductFromDB is null)
            {
                dbContext.CartProducts.Add(cartProduct);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                //increase quantity
                cartProductFromDB.ProductQuantity += cartProduct.ProductQuantity;
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
