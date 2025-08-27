using OrderMicroservice.Domain.Interfaces;

namespace OrderMicroservice.Domain.Events
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent domainEvent)
        {
            // Log stuff ($"✅ Domain Event Handled: Order {domainEvent.OrderId} was created at {domainEvent.OccurredOn}") to TableStorage;

            return Task.CompletedTask;
        }
    }
}
