namespace Application.Dtos
{
    public class OrderProductDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid OrderId { get; set; }
        public ProductDto Product { get; set; } = new ProductDto();
        public OrderDto Order { get; set; } = new OrderDto();
    }
}
