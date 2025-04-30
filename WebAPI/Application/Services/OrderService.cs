using Application.Pocos;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;
using Microsoft.Extensions.Options;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly FeatureFlags _featureFlags;
        private static readonly decimal CurrentTax = 0.3m; // Calculo em vigor
        private static readonly decimal TaxReform = 0.2m; // Calculo refora tributária

        public OrderService(IOrderRepository repository, IOptions<FeatureFlags> featureFlags)
        {
            _repository = repository;
            _featureFlags = featureFlags.Value;
        }

        public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var isOrderDuplicated = await IsOrderDuplicated(entity);

            var totalValueTaxApplied = _featureFlags.UseTaxReform
                ? CalculateTaxReform(entity)
                : CalculateCurrentTax(entity);

            entity.Tax = totalValueTaxApplied;

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
            var totalItemsValue = CalculateOrdersItemsTotalValue(order);
            return totalItemsValue * CurrentTax;
        }

        public decimal CalculateTaxReform(Order order)
        {
            var totalItemsValue = CalculateOrdersItemsTotalValue(order);
            return totalItemsValue * TaxReform;
        }

        public async Task<bool> IsOrderDuplicated(Order order)
        {
            var existingOrders = await _repository.GetOrdersBasedOnUsersData(order.UserId, order.ClientId, order.Items.Count);

            if (!existingOrders.Any())
                return false;

            foreach(var existingOrder in existingOrders)
            {
                var sameProducts = !order.Items
                    .ExceptBy(order.Items.Select(x => x.ProductId), x => x.ProductId)
                    .Any();

                if (sameProducts)
                    return true;
            }

            return false;
        }

        public decimal CalculateOrdersItemsTotalValue(Order order)
        {
            var totalItemsValue = order.Items.Sum(x => x.Price * x.Quantity);
            return totalItemsValue;
        }
    }
}
