using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<ICollection<Order>> GetOrdersBasedOnUsersData(Guid userId, Guid clientId, int count);
    }
}
