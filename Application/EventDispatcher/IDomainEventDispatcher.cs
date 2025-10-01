using OrderMicroservice.Domain.Interfaces;

namespace OrderMicroservice.Application.EventDispatcher
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents);
    }
}