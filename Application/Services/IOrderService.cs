using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Application.Services
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync();
        Task AddItemToOrderAsync(Guid orderId, Guid productId, int quantity, decimal unitPrice);
        Task<Order> getOrderById(Guid orderId);
    }
}
