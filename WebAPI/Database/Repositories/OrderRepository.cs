using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    /// <summary>
    /// Implementation of IOrderRepository using Entity Framework Core.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ProductRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public OrderRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new order in the database.
        /// </summary>
        /// <param name="Order">A order and it's details.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The created order.</returns>
        public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            await _context.Orders.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }


        /// <summary>
        /// Deletes a order from the database based on it's Id.
        /// </summary>
        /// <param name="id">The unique identifier of the order to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>True if the order was deleted, false if not found.</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }

        /// <summary>
        /// Retrieves all orders from the database.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of immutable orders.</returns>
        public async Task<IReadOnlyList<Order>?> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _context.Orders.ToListAsync(cancellationToken).ConfigureAwait(false);

            if (orders == null)
                return null;

            return orders;
        }

        /// <summary>
        /// Retrieve a order by it's Guid Id from the database
        /// </summary>
        /// <param name="id">The unique identifier of the order to be retrieved.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A order if it's found or, if not, a default object.</returns>
        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);

            return order;
        }

        /// <summary>
        /// Update a order register replacing it by the new register. This changes all the entity.
        /// </summary>
        /// <param name="order">The new order entity to be registered.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Creates a new order, if no equally product is found beforehand,
        /// otherwise, update the existant order entity by the new one.</returns>
        public async Task<Order> UpdateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var existantOrder = await GetByIdAsync(entity.Id, cancellationToken).ConfigureAwait(false);

            if (existantOrder == null)
                await _context.Orders.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            else
                _context.Orders.Update(entity);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public async Task<ICollection<Order>> GetOrdersBasedOnUsersData(Guid userId, Guid clientId, int count)
        {
            var existingOrders = await _context.Orders
                .Include(x => x.Items)
                .Where(x => x.ClientId == clientId &&
                    x.UserId == userId &&
                    x.Items.Count == count)
                .ToListAsync();

            return existingOrders;
        }
    }
}
