﻿using System.Linq;
using MyStore.Domain.Models;
using MyStore.Domain.Repositories;
using MyStore.Services.Contracts.Category;
using MyStore.Tests.Unit.Framework;
using NUnit.Framework;
using SpecsFor.Core.ShouldExtensions;

namespace MyStore.Tests.Unit.ServiceTests.CategoryServiceTests
{
    [TestFixture]
    public class When_Updating : SpecsForCategoryService
    {
        private Category _model;
        private CategoryDto _dto;
        private CategoryDto _result;

        protected override void Given()
        {
            base.Given();

            _model = Categories.First();

            _dto = new CategoryDto
            {
                Id = _model.Id,
                Name = GetRandom.String(255),
                Description = GetRandom.String(255)
            };
        }

        protected override async void When()
        {
            base.When();

            _result = await SUT.UpdateAsync(AdminUserId, _dto);
        }

        [Test]
        public void Then_SaveChanges_was_called()
        {
            GetMockFor<ICategoryRepository>()
                .Verify(x => x.SaveChangesAsync(AdminUserId));
        }

        [Test]
        public void Then_the_database_was_updated()
        {
            _model.ShouldLookLikePartial(new
            {
                _dto.Id,
                _dto.Name,
                _dto.Description
            });
        }

        [Test]
        public void Then_the_updated_model_was_retrieved_from_the_repository()
        {
            GetMockFor<ICategoryRepository>()
                .Verify(x => x.GetAsync(AdminUserId, _model.Id));
        }

        [Test]
        public void Then_the_updated_model_was_returned()
        {
            _result.ShouldLookLikePartial(new
            {
                _dto.Id,
                _dto.Name,
                _dto.Description
            });
        }
    }
}
