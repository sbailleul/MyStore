using System.Collections.Generic;
using MyStore.Domain.Models;
using MyStore.Tests.Unit.Framework.Mothers;
using NUnit.Framework;
using Shouldly;

namespace MyStore.Tests.Unit.DomainTests.RepositoryTests.ProductRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Product_range : Given_a_ProductRepository
    {
        private List<Product> _models;
        private int _originalCount;

        protected override void Given()
        {
            base.Given();

            _models = new List<Product>
            {
                ProductMother.Typical(),
                ProductMother.Typical()
            };

            _originalCount = SUT.CountAsync().Result;
        }

        protected override void When()
        {
            base.When();

            SUT.AddRangeAsync(AdminUserId, _models).Wait();
        }

        [Test]
        public void Then_the_new_Products_should_have_an_Id()
        {
            _models.ForEach(x => x.Id.ShouldBeGreaterThan(0));
        }

        [Test]
        public void Then_the_new_Products_were_added_to_the_table()
        {
            SUT.CountAsync().Result.ShouldBe(_originalCount + _models.Count);
        }
    }
}
