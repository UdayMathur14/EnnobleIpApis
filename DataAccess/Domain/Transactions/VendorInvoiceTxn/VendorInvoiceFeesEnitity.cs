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
        public int? subFeeValue { get; set; }
        public int? country { get; set; }
        public int? amount { get; set; }
        public int? remarks { get; set; }
        public int? language { get; set; }

        public VendorInvoiceTxnEntity? VendorInvoiceTxnEntity { get; set; }
    }

}
