using AutoMapper;
using MyStore.Services;
using NUnit.Framework;

namespace MyStore.Tests.Unit
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            UseRealMappers();
        }

        private void UseRealMappers()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(Startup).Assembly));
        }
    }
}
