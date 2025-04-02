using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public Order()
        {
            Status = OrderStatus.Created;
        }

        public required Guid ClientId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Tax { get; set; }
        public IEnumerable<OrderProduct> Items { get; set; }
    }
}
