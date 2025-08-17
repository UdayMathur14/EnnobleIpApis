using DataAccess.Domain.Masters.VendorInvoiceTxn;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Transactions.VendorInvoiceTxn
{
    [Table("SALE_INVOICE_DETAIL_TXN")]
    public class VendorSalesInvoiceEntity
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("VendorInvoiceTxnEntity")]
        public int VendorInvoiceTxnID { get; set; }
        public string type { get; set; }
        public string? invoiceNo { get; set; }
        public decimal? amount { get; set; }
        public string? estimateNo { get; set; }
        public string? remarks { get; set; }
        public string? postedInTally { get; set; }
        public VendorInvoiceTxnEntity? VendorInvoiceEntity { get; set; }
    }

}
