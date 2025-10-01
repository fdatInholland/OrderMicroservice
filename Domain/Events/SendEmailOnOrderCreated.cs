using OrderMicroservice.Domain.Interfaces;

namespace OrderMicroservice.Domain.Events
{
    public class SendEmailOnOrderCreated : IEventHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent domainEvent)
        {
            // Send email 
            return Task.CompletedTask;
        }
    }
}
