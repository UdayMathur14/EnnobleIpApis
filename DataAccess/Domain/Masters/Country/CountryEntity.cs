using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Masters.Country
{
    [Table("COUNTRY_MST_TB")]
    public class CountryEntity : EntityBase
    {

        
        [StringLength(255)]
        public string? CountryName { get; set; }

        
        [StringLength(50)]
        public string? CountryCode { get; set; }

        
        [StringLength(255)]
        public string? CurrencyName { get; set; }

        
        [StringLength(50)]
        public string? CurrencyCode { get; set; }

        [StringLength(10)]
        public string? Symbol { get; set; }
    }
}
