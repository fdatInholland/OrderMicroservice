using OrderMicroservice.Domain.Interfaces;

namespace OrderMicroservice.Domain.Events
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public Guid OrderId { get; }
        public DateTime OccurredOn { get; }

        public OrderCreatedEvent(Guid orderId)
        {
            OrderId = orderId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
