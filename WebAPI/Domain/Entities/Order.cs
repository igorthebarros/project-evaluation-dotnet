using Domain.Enums;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Status = OrderStatus.Created;
        }

        public Guid ClientId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Tax { get; set; }
        // Foreign Key
        public Guid UserId { get; set; }
        // Navigation
        public User User { get; set; } = new User();
        public ICollection<OrderProduct> Items { get; set; } = new List<OrderProduct>();
    }
}
