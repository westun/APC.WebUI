using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrderAsync(int orderId);
        Task<IEnumerable<OrderDTO>> GetOrdersAsync(int accountId);
        Task<OrderDTO> SaveOrderAsync(OrderDTO orderDTO);
    }
}