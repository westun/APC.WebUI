using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(int orderId);
        Task<IEnumerable<Order>> GetAllAsync(int accountId);
        Task<Order> SaveAsync(Order order);
    }
}