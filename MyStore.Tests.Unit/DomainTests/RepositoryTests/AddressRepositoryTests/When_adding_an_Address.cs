﻿using MyStore.Domain.Models;
using MyStore.Tests.Unit.Framework.Builders;
using NUnit.Framework;
using Shouldly;

namespace MyStore.Tests.Unit.DomainTests.RepositoryTests.AddressRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Address : Given_an_AddressRepository
    {
        private Address _model;
        private Address _result;

        protected override void Given()
        {
            base.Given();

            _model = AddressBuilder.Typical().Build();
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_Address_should_have_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }
    }
}
