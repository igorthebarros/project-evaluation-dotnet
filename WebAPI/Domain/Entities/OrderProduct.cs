namespace Domain.Entities
{
    public class OrderProduct : BaseEntity
    {
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        // Foreign Key
        public Guid OrderId { get; set; }
        // Navigation
        public Product Product { get; set; } = new Product();
        public Order Order { get; set; } = new Order();
    }
}
