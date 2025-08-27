namespace OrderMicroservice.Domain.Orders
{
    public class OrderItem
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        private OrderItem() { } // EF Core

        public OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero");
            if (unitPrice <= 0) throw new ArgumentException("Unit price must be greater than zero");

            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public decimal GetTotal() => Quantity * UnitPrice;
    }
}
