using System.Linq;
using MyStore.Domain.Models;
using MyStore.Domain.Repositories;
using NUnit.Framework;

namespace MyStore.Tests.Unit.ServiceTests.AddressServiceTests
{
    [TestFixture]
    public class When_Deleting : SpecsForAddressService
    {
        private Address _model;

        protected override void Given()
        {
            base.Given();

            _model = Addresses.First();
        }

        protected override async void When()
        {
            base.When();

            await SUT.DeleteAsync(AdminUserId, _model.Id);
        }

        [Test]
        public void Then_the_model_was_deleted_from_the_repository()
        {
            GetMockFor<IAddressRepository>().Verify(x => x.DeleteAsync(AdminUserId, _model.Id));
        }
    }
}
