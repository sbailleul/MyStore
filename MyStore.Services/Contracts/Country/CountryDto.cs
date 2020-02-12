using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyStore.Services.Contracts.State;
using MyStore.Services.Framework;

namespace MyStore.Services.Contracts.Country
{
    public class CountryDto : LookupDto
    {
        public CountryDto()
        {
            States = new HashSet<StateDto>();
        }

        [StringLength(3)]
        public string Abbreviation { get; set; }

        [StringLength(50)]
        public string PostalCodeLabel { get; set; }

        [StringLength(50)]
        public string StateLabel { get; set; }

        public ICollection<StateDto> States { get; set; }
    }
}
