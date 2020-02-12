using MyStore.Domain.Models;
using MyStore.Tests.Unit.Framework.Mothers;
using NUnit.Framework;
using Shouldly;

namespace MyStore.Tests.Unit.DomainTests.RepositoryTests.ProductRepositoryTests
{
    [TestFixture]
    public class When_adding_a_Product : Given_a_ProductRepository
    {
        private Product _model;
        private Product _result;

        protected override void Given()
        {
            base.Given();

            _model = ProductMother.Typical();
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_Product_should_have_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }
    }
}
