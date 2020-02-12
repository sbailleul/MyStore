using System.Linq;
using MyStore.Domain.Models;
using MyStore.Services.Contracts.Category;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;

namespace MyStore.Tests.Unit.ServiceTests.CategoryServiceTests
{
    [TestFixture]
    public class When_Getting_by_Id : SpecsForCategoryService
    {
        private CategoryDto _result;
        private Category _expected;

        protected override void Given()
        {
            base.Given();
            _expected = Categories.First();
        }

        protected override async void When()
        {
            base.When();
            _result = await SUT.GetAsync(AdminUserId, _expected.Id);
        }

        [Test]
        public void Then_only_the_matching_model_was_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _expected.Id,
                _expected.Name,
                _expected.Description
            });
        }
    }
}
