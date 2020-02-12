using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Framework;
using MyStore.Domain.Models;
using SpecsFor.StructureMap;
using StructureMap;

namespace MyStore.Tests.Unit.Framework
{
    public abstract class SpecsForRepository<TRepository> : SpecsFor<TRepository> where TRepository : Repository
    {
        protected override void AfterSpec()
        {
            base.AfterSpec();
            _connection.Close();
        }

        protected readonly int AdminUserId = 1;
        private SqliteConnection _connection;

        public override void ConfigureContainer(Container container)
        {
            base.ConfigureContainer(container);
            container.Configure(x => x.For<StoreContext>().Use(CreateStoreContext()));
        }

        protected StoreContext CreateStoreContext()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var builder = new DbContextOptionsBuilder<StoreContext>()
                .EnableSensitiveDataLogging()
                .UseSqlite(_connection);
            var context = new StoreContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
    }
}
