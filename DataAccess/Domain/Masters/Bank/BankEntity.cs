using DataAccess.Domain.Masters.VendorInvoiceTxn;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Domain.Masters.Bank
{

    [Table("BANK_MST_TB")]
    public class BankEntity : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string? BankName { get; set; }

        [StringLength(255)]
        public string? BankBranch { get; set; }

        [Required]
        [StringLength(20)]
        public string? IFSCCode { get; set; }

        [Required]
        [StringLength(50)]
        public string? AccountNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string? AccountHolderName { get; set; }

        [StringLength(50)]
        public string? AccountType { get; set; }
        public string? BankAddress1 { get; set; }
        public string? BankAddress2 { get; set; }
        public string? City { get; set; }
        public string? State{ get; set; }
        public string? Country { get; set; }
        public string? BankContactNo { get; set; }
        public string? BankEmailId { get; set; }
    }
}
