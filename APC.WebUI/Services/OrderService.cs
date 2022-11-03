using APC.DAL.Models;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<OrderDTO> GetOrderAsync(int orderId)
        {
            var order = await this.orderRepository.GetAsync(orderId);

            return this.mapper.Map<OrderDTO>(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersAsync(int accountId)
        {
            var order = await this.orderRepository.GetAllAsync(accountId);

            return this.mapper.Map<IEnumerable<OrderDTO>>(order);
        }

        public async Task<OrderDTO> SaveOrderAsync(OrderDTO orderDTO)
        {
            var order = this.mapper.Map<Order>(orderDTO);

            var orderFromDB = await this.orderRepository.SaveAsync(order);

            return this.mapper.Map<OrderDTO>(orderFromDB);
        }
    }
}
