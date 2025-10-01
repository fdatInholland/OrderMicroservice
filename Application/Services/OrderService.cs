using OrderMicroservice.Application.EventDispatcher;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.Interfaces;
using OrderMicroservice.Infrastructure.Persistance;

namespace OrderMicroservice.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepsitory<Order> _orderRepository;
        private readonly IDomainEventDispatcher _dispatcher;

        public OrderService(IOrderRepsitory<Order> orderRepository, IDomainEventDispatcher eventDispatcher)
        {
            _orderRepository = orderRepository;
            _dispatcher = eventDispatcher;
        }

        public async Task AddItemToOrderAsync(Guid orderId, Guid productId, int quantity, decimal unitPrice)
        {
            Order order = await _orderRepository.GetByIdAsync(orderId);
            if (order is null)
                throw new InvalidOperationException("Order not found");

            order.AddItem(productId, quantity, unitPrice);

            await _orderRepository.SaveChangesAsync();
        }

        public async Task<Guid> CreateOrderAsync()
        {
            Order order = new Order(Guid.NewGuid());
            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            await _dispatcher.DispatchAsync(order.DomainEvents);
            order.ClearDomainEvents();

            return order.OrderId;
        }

        public async Task<Order> getOrderById(Guid orderId)
        {
             return await _orderRepository.GetByIdAsync(orderId);
        }
    }
}
