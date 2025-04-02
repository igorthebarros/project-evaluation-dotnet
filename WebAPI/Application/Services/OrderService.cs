using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.CreateAsync(entity, cancellationToken).ConfigureAwait(false);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var wasDeleted = await _repository.DeleteAsync(id, cancellationToken).ConfigureAwait(false);
            return wasDeleted;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _repository.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return orders;
        }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _repository.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
            return order;
        }

        public async Task<Order> UpdateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var order = await _repository.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);
            return order;
        }

        public decimal CalculateCurrentTax(Order order)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTaxReform(Order order)
        {
            throw new NotImplementedException();
        }

        public decimal GetFullTaxValue(Order order)
        {
            throw new NotImplementedException();
        }

        public bool IsOrderDuplicated(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
