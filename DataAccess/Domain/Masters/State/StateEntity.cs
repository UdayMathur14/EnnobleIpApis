using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Masters.State
{
    [Table("STATE_MST_TB")]
    public class StateEntity : EntityBase
    {
        [Column("StateName")]
        [StringLength(255)]
        public string? StateName { get; set; }

        [StringLength(50)]
        [Column("CountryName")]
        public string? CountryName { get; set; }

    }
}
