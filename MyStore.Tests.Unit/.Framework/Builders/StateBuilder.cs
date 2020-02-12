using MyStore.Domain.Models;

namespace MyStore.Tests.Unit.Framework.Builders
{
    public partial class StateBuilder
    {
        protected override void PostBuild(State value)
        {
            value?.Country?.States?.Add(value);
        }

        public static StateBuilder Simple()
        {
            return Default()
                .WithAbbreviation(GetRandom.String(2, 2))
                .WithName(GetRandom.String(1, 50))
                .WithCountry(CountryBuilder.Simple().Build());
        }

        public static StateBuilder Typical()
        {
            return Simple()
                .WithDescription(GetRandom.String(1, 255));
        }
    }
}
