using OrderMicroservice.Domain.Interfaces;

namespace OrderMicroservice.Domain.Orders
{
    public class Order : IAggregateRoot
    {
        private readonly List<OrderItem> _items = new();
        private readonly List<IDomainEvent> _domainEvents = new();

        public Guid OrderId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        public decimal Total => _items.Sum(i => i.GetTotal());

        private Order() { } // For EF Core

        public Order(Guid orderid)
        {
            OrderId = orderid;
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new Events.OrderCreatedEvent(orderid));
        }

        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                var newQuantity = existingItem.Quantity + quantity;
                _items.Remove(existingItem);
                _items.Add(new OrderItem(productId, newQuantity, unitPrice));
            }
            else
            {
                _items.Add(new OrderItem(productId, quantity, unitPrice));
            }
        }

        private void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
