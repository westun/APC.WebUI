using APC.DAL.Models;

namespace APC.DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> SaveAsync(Order order);
    }
}