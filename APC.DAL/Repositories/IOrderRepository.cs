using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(int orderId);
        Task<Order> SaveAsync(Order order);
    }
}