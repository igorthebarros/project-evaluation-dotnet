using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
