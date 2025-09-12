using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Domain.Masters.Bank
{

    [Table("BANK_MST_TB")]
    public class BankEntity : EntityBase
    {
        [Column("BANK_NAME")]
        [Required]
        [StringLength(255)]
        public string? BankName { get; set; }

        [Column("BANK_BRANCH")]
        [StringLength(255)]
        public string? BankBranch { get; set; }

        [Column("IFSCCODE")]
        [Required]
        [StringLength(20)]
        public string? IFSCCode { get; set; }

        [Column("ACCOUNT_NUMBER")]
        [Required]
        [StringLength(50)]
        public string? AccountNumber { get; set; }

        [Column("ACCOUNT_HOLDER_NAME")]
        [Required]
        [StringLength(255)]
        public string? AccountHolderName { get; set; }

        [StringLength(50)]
        [Column("ACCOUNT_TYPE")]
        public string? AccountType { get; set; }

        [Column("BANK_ADDRESS1")]
        public string? BankAddress1 { get; set; }

        [Column("BANK_ADDRESS2")]
        public string? BankAddress2 { get; set; }

        [Column("CITY")]
        public string? City { get; set; }

        [Column("STATE")]
        public string? State{ get; set; }

        [Column("COUNTRY")]
        public string? Country { get; set; }

        [Column("BANK_CONTACTNO")]
        public string? BankContactNo { get; set; }

        [Column("BANK_EMAIL_ID")]
        public string? BankEmailId { get; set; }
    }
}
