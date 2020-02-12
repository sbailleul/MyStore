using MyStore.Services.Framework;
using SpecsFor.StructureMap;
using StructureMap;

namespace MyStore.Tests.Unit.Framework
{
    public abstract class SpecsForService<TService> : SpecsFor<TService> where TService : Service
    {
        protected readonly int AdminUserId = 1;

        public override void ConfigureContainer(Container container)
        {
            base.ConfigureContainer(container);

            // Fake configuration values
            var mockConfiguration = GetMockFor<Microsoft.Extensions.Configuration.IConfiguration>();
        }
    }
}
