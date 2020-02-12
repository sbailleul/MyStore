using System.Linq;
using MyStore.Domain.Models;
using MyStore.Domain.Repositories;
using NUnit.Framework;

namespace MyStore.Tests.Unit.ServiceTests.ProductServiceTests
{
    [TestFixture]
    public class When_Deleting : SpecsForProductService
    {
        private Product _model;

        protected override void Given()
        {
            base.Given();

            _model = Products.First();
        }

        protected override async void When()
        {
            base.When();

            await SUT.DeleteAsync(AdminUserId, _model.Id);
        }

        [Test]
        public void Then_the_model_was_deleted_from_the_repository()
        {
            GetMockFor<IProductRepository>().Verify(x => x.DeleteAsync(AdminUserId, _model.Id));
        }
    }
}
