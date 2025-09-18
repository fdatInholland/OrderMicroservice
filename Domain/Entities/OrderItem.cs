namespace OrderMicroservice.Domain.Entities
{
    public class OrderItem
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        private OrderItem() { } // needed for EF Core

        internal OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            //roll your own Exceptions!
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero");
            if (unitPrice <= 0) throw new ArgumentException("Unit price must be greater than zero");

            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public decimal GetTotal()
        {
            return Quantity * UnitPrice;
        }
    }
}
