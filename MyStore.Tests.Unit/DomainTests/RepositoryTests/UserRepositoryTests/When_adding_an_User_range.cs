using System.Collections.Generic;
using MyStore.Domain.Models;
using MyStore.Tests.Unit.Framework.Mothers;
using NUnit.Framework;
using Shouldly;

namespace MyStore.Tests.Unit.DomainTests.RepositoryTests.UserRepositoryTests
{
    [TestFixture]
    public class When_adding_an_User_range : Given_a_UserRepository
    {
        private List<User> _models;
        private int _originalCount;

        protected override void Given()
        {
            base.Given();

            _models = new List<User>
            {
                UserMother.Typical(),
                UserMother.Typical()
            };

            _originalCount = SUT.CountAsync().Result;
        }

        protected override void When()
        {
            base.When();

            SUT.AddRangeAsync(AdminUserId, _models).Wait();
        }

        [Test]
        public void Then_the_new_Users_should_have_an_Id()
        {
            _models.ForEach(x => x.Id.ShouldBeGreaterThan(0));
        }

        [Test]
        public void Then_the_new_Users_were_added_to_the_table()
        {
            SUT.CountAsync().Result.ShouldBe(_originalCount + _models.Count);
        }
    }
}
