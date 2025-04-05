using Models.RequestModels;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Domain.Masters.Country
{
    public class CountrySearchRequestEntity
    {
        [Required]
        [StringLength(255)]
        public string CountryName { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(255)]
        public string CurrencyName { get; set; }

        [Required]
        [StringLength(50)]
        public string CurrencyCode { get; set; }

        [StringLength(10)]
        public string? Symbol { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; } 
        public int Count { get; set; }
    }
}
