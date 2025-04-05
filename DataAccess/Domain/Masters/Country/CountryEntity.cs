using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Masters.Country
{
    [Table("COUNTRY_MST_TB")]
    public class CountryEntity : EntityBase
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
    }
}
