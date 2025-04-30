namespace Application.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public ICollection<OrderProductDto> OrderProducts { get; set; } = new List<OrderProductDto>();
    }
}
