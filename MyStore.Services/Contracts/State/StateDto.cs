using System.ComponentModel.DataAnnotations;
using MyStore.Services.Contracts.Country;
using MyStore.Services.Framework;

namespace MyStore.Services.Contracts.State
{
    public class StateDto : Dto
    {
        public string Abbreviation { get; set; }

        public CountryDto Country { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
