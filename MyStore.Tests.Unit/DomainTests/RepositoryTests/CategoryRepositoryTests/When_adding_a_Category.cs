using MyStore.Domain.Models;
using MyStore.Tests.Unit.Framework.Builders;
using NUnit.Framework;
using Shouldly;

namespace MyStore.Tests.Unit.DomainTests.RepositoryTests.CategoryRepositoryTests
{
    [TestFixture]
    public class When_adding_a_Category : Given_a_CategoryRepository
    {
        private Category _model;
        private Category _result;

        protected override void Given()
        {
            base.Given();

            _model = CategoryBuilder.Typical().Build();
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_Category_should_have_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }
    }
}
