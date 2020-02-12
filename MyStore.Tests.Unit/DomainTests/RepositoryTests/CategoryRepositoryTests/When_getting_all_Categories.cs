using System.Collections.Generic;
using MyStore.Domain.Models;
using NUnit.Framework;
using Shouldly;

namespace MyStore.Tests.Unit.DomainTests.RepositoryTests.CategoryRepositoryTests
{
    [TestFixture]
    public class When_getting_all_Categories : Given_a_CategoryRepository
    {
        private List<Category> _models;

        protected override void When()
        {
            base.When();

            _models = SUT.GetAsync(AdminUserId).Result;
        }

        [Test]
        public void Then_multiple_Categories_are_returned()
        {
            _models.Count.ShouldBeGreaterThan(1);
        }
    }
}
