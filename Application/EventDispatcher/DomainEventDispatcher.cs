using OrderMicroservice.Domain.Interfaces;
using System;

namespace OrderMicroservice.Application.EventDispatcher
{
    public class DomainEventDispatcher
    {

        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        private readonly IEnumerable<object> _handlers;

        public DomainEventDispatcher(IEnumerable<object> handlers)
        {
            _handlers = handlers;
        }

        public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                var handlerType = typeof(object);

                var eventType = domainEvent.GetType();
                var handlerInterface = typeof(IEventHandler<>).MakeGenericType(eventType);

                var handlers = _serviceProvider.GetServices(handlerInterface);

                foreach (var handler in handlers)
                {
                    var method = handlerInterface.GetMethod("Handle");
                    if (method != null)
                    {
                        var result = method.Invoke(handler, new object[] { domainEvent });
                        if (result is Task task) await task;
                    }
                }
            }
        }
    }
}
