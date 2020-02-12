using MyStore.Domain.Models;
using MyStore.Tests.Unit.Framework.Mothers;
using NUnit.Framework;
using Shouldly;

namespace MyStore.Tests.Unit.DomainTests.RepositoryTests.OrderItemRepositoryTests
{
    [TestFixture]
    public class When_adding_an_OrderItem : Given_an_OrderItemRepository
    {
        private OrderItem _model;
        private OrderItem _result;

        protected override void Given()
        {
            base.Given();

            var order = OrderMother.Simple();

            _model = new OrderItem
            {
                Order = order,
                Price = 1.00m,
                ProductId = 1
            };

            order.OrderItems.Add(_model);
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_OrderItem_should_have_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }
    }
}
