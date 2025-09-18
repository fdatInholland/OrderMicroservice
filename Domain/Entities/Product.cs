namespace OrderMicroservice.Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        
        //for EF Core
        private Product() { }
        
        public Product(Guid productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }
    }
}
