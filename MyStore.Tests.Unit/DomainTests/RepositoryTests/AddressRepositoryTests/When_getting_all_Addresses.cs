using System.Collections.Generic;
using MyStore.Domain.Models;
using NUnit.Framework;
using Shouldly;

namespace MyStore.Tests.Unit.DomainTests.RepositoryTests.AddressRepositoryTests
{
    [TestFixture]
    public class When_getting_all_Addresses : Given_an_AddressRepository
    {
        private List<Address> _models;

        protected override void When()
        {
            base.When();

            _models = SUT.GetAsync(AdminUserId).Result;
        }

        [Test]
        public void Then_multiple_Addresses_are_returned()
        {
            _models.Count.ShouldBeGreaterThan(1);
        }
    }
}
