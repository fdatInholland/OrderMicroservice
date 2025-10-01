using OrderMicroservice.Domain.Events;
using OrderMicroservice.Domain.Interfaces;

namespace OrderMicroservice.Domain.Entities
{
    public class Order : IAggregateRoot
    {
        public Guid OrderId { get; private set; }
        public decimal PaidAmount { get; private set; }
        public OrderStatus orderstatus { get; private set; }
        public int Quantity { get; private set; }
        public DateTime CreatedAt { get; private set; }

        //ReadOnly : Good practice for DDD
        private readonly List<OrderItem> _items = new();
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public decimal CalcTotalOrder()
        {
           return _items.Sum(i => i.GetTotal());
        }

        //for EF Core
        private Order() { }

        public Order(Guid orderid)
        {
            OrderId = orderid;
            orderstatus = OrderStatus.PendingPayment;
            PaidAmount = 0;
            Quantity = 0;

            //better: have the orderitems added to the order before raising the event
            //even better: all in a transactional way
            AddDomainEvent(new OrderCreatedEvent(orderid));
        }

        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem is not null)
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

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
