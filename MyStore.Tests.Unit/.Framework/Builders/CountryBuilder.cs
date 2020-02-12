namespace MyStore.Tests.Unit.Framework.Builders
{
    public partial class CountryBuilder
    {
        public static CountryBuilder Simple()
        {
            return MyStore.Tests.Unit.Framework.Builders.CountryBuilder.Default()
                .WithAbbreviation(GetRandom.String(2, 2))
                .WithName(GetRandom.String(1, 50));
        }

        public static CountryBuilder Typical()
        {
            return Simple()
                .WithDescription(GetRandom.String(1, 255));
        }
    }
}
