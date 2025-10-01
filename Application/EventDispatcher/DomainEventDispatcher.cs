using OrderMicroservice.Domain.Interfaces;

namespace OrderMicroservice.Application.EventDispatcher
{
    public class DomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                var eventType = domainEvent.GetType();
                var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);

                var handlers = _serviceProvider.GetServices(handlerType);

                foreach (var handler in handlers)
                {
                    await ((dynamic)handler).Handle((dynamic)domainEvent);
                }
            }
        }
    }
}
