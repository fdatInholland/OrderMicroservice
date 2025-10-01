using OrderMicroservice.Domain.Interfaces;

namespace OrderMicroservice.Domain.Events
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent domainEvent)
        {
            // Log stuff;

            return Task.CompletedTask;
        }
    }
}
