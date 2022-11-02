﻿using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public OrderRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<Order> SaveAsync(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            if (order.AccountId <= 0)
            {
                throw new Exception("To save an order, there must be an account id");
            }

            if (order.Created == DateTime.MinValue)
            {
                order.Created = DateTimeOffset.UtcNow;
            }

            if (order.OrderItems is null || !order.OrderItems.Any())
            {
                throw new Exception("To save an order, order items are required");
            }

            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var orderFromDB = dbContext.Order.FirstOrDefault(o => o.Id == order.Id);
            if (orderFromDB is null)
            {
                dbContext.Add(order);
                await dbContext.SaveChangesAsync();

                return order;
            }

            return orderFromDB;
        }
    }
}
