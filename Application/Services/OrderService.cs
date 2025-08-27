
using OrderMicroservice.Application.EventDispatcher;
using OrderMicroservice.Domain.Interfaces;
using OrderMicroservice.Domain.Orders;

namespace OrderMicroservice.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly DomainEventDispatcher _dispatcher;

        public OrderService(IOrderRepository orderRepository, DomainEventDispatcher eventDispatcher)
        {
            _orderRepository = orderRepository;
            _dispatcher = eventDispatcher;
        }

        public async Task AddItemToOrderAsync(Guid orderId, Guid productId, int quantity, decimal unitPrice)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new InvalidOperationException("Order not found");

            order.AddItem(productId, quantity, unitPrice);

            await _orderRepository.SaveChangesAsync();
        }

        public async Task<Guid> CreateOrderAsync()
        {
            var order = new Order(Guid.NewGuid());
            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            await _dispatcher.DispatchAsync(order.DomainEvents);
            order.ClearDomainEvents();

            return order.OrderId;
        }
    }
}
