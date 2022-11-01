using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> SaveOrderAsync(OrderDTO orderDTO);
    }
}