using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyStore.Domain.Framework;

namespace MyStore.Domain.Models
{
    public class Country : Lookup
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public string Abbreviation { get; set; }

        public ICollection<State> States { get; set; }

        [MaxLength(50)]
        public string StateLabel { get; set; }

        [MaxLength(50)]
        public string PostalCodeLabel { get; set; }
    }
}
