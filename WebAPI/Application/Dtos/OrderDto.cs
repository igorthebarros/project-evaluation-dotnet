using Domain.Entities;

namespace Application.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid ClientId { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Tax { get; set; }
        public Guid UserId { get; set; }
        public ICollection<OrderProduct> Items { get; set; } = new List<OrderProduct>();
    }
}
