using System.Linq;
using MyStore.Domain.Models;
using MyStore.Services.Contracts.State;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;

namespace MyStore.Tests.Unit.ServiceTests.StateServiceTests
{
    [TestFixture]
    public class When_Getting_by_Id : SpecsForStateService
    {
        private StateDto _result;
        private State _expected;

        protected override void Given()
        {
            base.Given();
            _expected = Countries.First();
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
                _expected.Abbreviation,
                _expected.Description,
                _expected.Name
            });
        }
    }
}
