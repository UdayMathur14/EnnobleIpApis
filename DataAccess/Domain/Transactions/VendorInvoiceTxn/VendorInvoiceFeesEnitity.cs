using DataAccess.Domain.Masters.VendorInvoiceTxn;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Transactions.VendorInvoiceTxn
{
    [Table("VENDOR_INVOICE_FEES")]
    public class VendorInvoiceFeesEntity
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("VendorInvoiceTxnEntity")]
        public int VendorInvoiceTxnID { get; set; }

        public int FeeTypeID { get; set; }  // From dropdown (e.g., Professional Fee, Govt Fee etc.)

        public int? CountryID { get; set; } // From dropdown

        public int Amount { get; set; }

        [MaxLength(500)]
        public string? Remarks { get; set; }

        public VendorInvoiceTxnEntity? VendorInvoiceTxnEntity { get; set; }
    }

}
