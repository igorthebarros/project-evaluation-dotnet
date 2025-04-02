using Domain.Entities;

namespace Domain.Contracts.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        /// <summary>
        /// Check if order is duplicated or not, to avoid errors.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>A boolean to inform if is duplicated or not.</returns>
        bool IsOrderDuplicated(Order order);
        /// <summary>
        /// Will calculate the full tax value for a given order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>The total amount of tax for a given order.</returns>
        decimal GetFullTaxValue(Order order);
        /// <summary>
        /// Will calculate the current tax for a given order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>The value of the tax calculated.</returns>
        decimal CalculateCurrentTax(Order order);
        /// <summary>
        /// Will calculate the tax based on the reform for a given order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>The value of the tax calculated.</returns>
        decimal CalculateTaxReform(Order order);
    }
}
