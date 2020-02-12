using System.Collections.Generic;
using MyStore.Domain.Models;
using NUnit.Framework;
using Shouldly;

namespace MyStore.Tests.Unit.DomainTests.RepositoryTests.OrderRepositoryTests
{
    [TestFixture]
    public class When_getting_all_Orders : Given_an_OrderRepository
    {
        private List<Order> _models;

        protected override void When()
        {
            base.When();

            _models = SUT.GetAsync(AdminUserId).Result;
        }

        [Test]
        public void Then_multiple_Orders_are_returned()
        {
            _models.Count.ShouldBeGreaterThan(1);
        }
    }
}
