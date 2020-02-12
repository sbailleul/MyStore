using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using MyStore.Common.Contracts;
using MyStore.Domain.Models;
using MyStore.Domain.Repositories;
using MyStore.Services.Services;
using MyStore.Tests.Unit.Framework;
using NUnit.Framework;

namespace MyStore.Tests.Unit.ServiceTests.OrderServiceTests
{
    [TestFixture]
    public abstract class SpecsForOrderService : SpecsForService<OrderService>
    {
        protected List<Order> Orders;

        protected override void Given()
        {
            base.Given();

            Orders = new List<Order>
            {
                new Order { Id = 1,
                    BillingAddressId = GetRandom.Id(),
                    OrderStatusId = GetRandom.Id(),
                    ShippingAddressId = GetRandom.Id(),
                    UserId = GetRandom.Id(),
                },
            };

            GetMockFor<IOrderRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<Order>()))
                .Returns((int userId, Order model) => Task.FromResult(model))
                .Callback((int userId, Order model) =>
                {
                    model.Id = GetRandom.Id();
                    Orders.Add(model);
                });

            GetMockFor<IOrderRepository>()
                .Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Orders.SingleOrDefault(x => x.Id == id)))
                .Callback((int userId, int id) => { Orders.RemoveAll(x => x.Id == id); });

            GetMockFor<IOrderRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Orders.SingleOrDefault(x => x.Id == id)));

            GetMockFor<IOrderRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Order, bool>>>(), It.IsAny<PagingOptions>()))
                .Returns((int userId, Expression<Func<Order, bool>> predicate, PagingOptions queryOptions) => Task.FromResult(Orders.AsQueryable().Where(predicate).ToList()));

            GetMockFor<IOrderRepository>()
                .Setup(x => x.SingleOrDefaultAsync(It.IsAny<int>(), It.IsAny<Expression<Func<Order, bool>>>()))
                .Returns((int userId, Expression<Func<Order, bool>> predicate) => Task.FromResult(Orders.AsQueryable().SingleOrDefault(predicate)));
        }
    }
}
