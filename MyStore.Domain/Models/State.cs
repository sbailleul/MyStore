using System.ComponentModel.DataAnnotations.Schema;
using MyStore.Domain.Framework;

namespace MyStore.Domain.Models
{
    public class State : Lookup
    {
        public string Abbreviation { get; set; }

        public Country Country { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
    }
}
