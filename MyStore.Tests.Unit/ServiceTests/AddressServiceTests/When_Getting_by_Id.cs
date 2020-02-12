using System.Linq;
using MyStore.Domain.Models;
using MyStore.Services.Contracts.Address;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;

namespace MyStore.Tests.Unit.ServiceTests.AddressServiceTests
{
    [TestFixture]
    public class When_Getting_by_Id : SpecsForAddressService
    {
        private AddressDto _result;
        private Address _expected;

        protected override void Given()
        {
            base.Given();
            _expected = Addresses.First();
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
                _expected.Line1,
                _expected.Line2,
                _expected.City,
                _expected.StateId,
                PostalCode = _expected.PostalCode
            });
        }
    }
}
