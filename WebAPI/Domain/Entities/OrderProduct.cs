namespace Domain.Entities
{
    public class OrderProduct
    {
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
