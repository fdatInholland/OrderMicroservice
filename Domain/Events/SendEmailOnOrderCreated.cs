using OrderMicroservice.Domain.Interfaces;
using OrderMicroservice.Domain.ValueObjects;

namespace OrderMicroservice.Domain.Events
{
    public class SendEmailOnOrderCreated : IEventHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent domainEvent)
        {
            // Send email 
            var Email = EmailAddress.From("blaat@com");

            return Task.CompletedTask;
        }
    }
}
