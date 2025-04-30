using System.ComponentModel.DataAnnotations;

namespace DataAccess.Domain.Masters.State
{
    public class StateSearchRequestEntity
    {
        [Required]
        [StringLength(255)]
        public string StateName { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        public string? Status { get; set; }
        public int Offset { get; set; } 
        public int Count { get; set; }
    }
}
