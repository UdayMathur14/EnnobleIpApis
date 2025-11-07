using DataAccess.Domain.Masters.Bank;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Transactions.VendorInvoiceTxn
{
    [Table("VENDOR_PAYMENT_DETAILS")]
    public class VendorPaymentInvoiceEntity
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("VendorInvoiceTxnEntity")]
        public int VendorInvoiceTxnID { get; set; }
        public DateTime? paymentDate { get; set; }
        public int? bankID { get; set; }
        public string? oWRMNo1 { get; set; }
        public string? oWRMNo2 { get; set; }
        public decimal? rate { get; set; } // Changed to decimal?
        public decimal? quantity { get; set; } // Changed to decimal?
        public decimal? bankcharges { get; set; } // Changed to decimal?
        public decimal? totalAmountInr { get; set; } // Changed to decimal?
        public string? paymentCurrency { get; set; }
        public decimal? paymentAmount { get; set; }
        public VendorInvoiceTxnEntity? VendorPaymentEntity { get; set; }
    }

}
