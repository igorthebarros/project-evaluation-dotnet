using Application.Pocos;
using Application.Services;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Moq;

namespace ApplicationTest.Services
{
    public class OrderServiceTest
    {
        private readonly Mock<IOrderRepository> _repositoryMock;
        private readonly IOrderService _service;

        public OrderServiceTest()
        {
            _repositoryMock = new Mock<IOrderRepository>();

            var featureFlags = Options.Create(new FeatureFlags { UseTaxReform = false });
            _service = new OrderService(_repositoryMock.Object, featureFlags);
        }

        [Fact]
        public void CalculateCurrentTax_ShouldReturnCorrectValue()
        {
            var order = new Order
            {
                Items = new List<OrderProduct>
            {
                new OrderProduct { Price = 10, Quantity = 2 },
                new OrderProduct { Price = 5, Quantity = 1 }
            }
            };

            var result = _service.CalculateCurrentTax(order);

            Assert.Equal(7.5m, result); // (10*2 + 5*1) * 0.3 = 25 * 0.3 = 7.5
        }

        [Fact]
        public void CalculateTaxReform_ShouldReturnCorrectValue()
        {
            var order = new Order
            {
                Items = new List<OrderProduct>
            {
                new OrderProduct { Price = 10, Quantity = 2 },
                new OrderProduct { Price = 5, Quantity = 1 }
            }
            };

            var featureFlags = Options.Create(new FeatureFlags { UseTaxReform = true });
            var service = new OrderService(_repositoryMock.Object, featureFlags);

            var result = service.CalculateTaxReform(order);

            Assert.Equal(5m, result); // (10*2 + 5*1) * 0.2 = 25 * 0.2 = 5
        }

        [Fact]
        public async Task IsOrderDuplicated_ShouldReturnTrue_WhenSameProductsExist()
        {
            var productId = Guid.NewGuid();
            var order = new Order
            {
                UserId = Guid.NewGuid(),
                ClientId = Guid.NewGuid(),
                Items = new List<OrderProduct>
            {
                new OrderProduct { ProductId = productId }
            }
            };

            var existingOrder = new Order
            {
                Items = new List<OrderProduct>
            {
                new OrderProduct { ProductId = productId }
            }
            };

            _repositoryMock.Setup(r => r.GetOrdersBasedOnUsersData(order.UserId, order.ClientId, order.Items.Count))
                .ReturnsAsync(new List<Order> { existingOrder });

            var result = await _service.IsOrderDuplicated(order);

            Assert.True(result);
        }
    }
}
