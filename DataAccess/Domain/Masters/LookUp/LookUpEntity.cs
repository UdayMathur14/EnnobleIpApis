using DataAccess.Domain.Masters.LookUpType;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Masters.LookUp
{
    [Table("LOOKUP_MST_TB")]
    public class LookUpEntity : EntityBase
    {
        [Column("TYPE_ID")]
        public int? TypeId { get; set; }

        [Column("CODE")]
        public string? Code { get; set; }

        [Column("VALUE")]
        public string? Value { get; set; }

        [Column("DESCRIPTION")]
        public string? Description { get; set; }

        [ForeignKey("TypeId")]
        public LookUpTypeEntity? LookUpType { get; set; }
    }

}
