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
        public string? feeType { get; set; }
        public string? subFeeValue { get; set; }
        public string? country { get; set; }
        public decimal? amount { get; set; }
        public string? remarks { get; set; }
        public string? language { get; set; }
        public VendorInvoiceTxnEntity? VendorInvoiceTxnEntity { get; set; }
    }

}
