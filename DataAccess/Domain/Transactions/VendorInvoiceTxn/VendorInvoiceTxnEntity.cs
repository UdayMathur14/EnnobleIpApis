using DataAccess.Domain.Masters.Customer;
using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Transactions.VendorInvoiceTxn;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Masters.VendorInvoiceTxn
{
    [Table("VENDOR_INVOICE_TXN")]
    public class VendorInvoiceTxnEntity :EntityBase
    {
        public int? VendorID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? FY { get; set; }
        public string? ClientInvoiceNo { get; set; }
        public DateTime? DueDateAsPerInvoice { get; set; }
        public int? CreditDaysAsPerContract { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DueDateAsPerContract { get; set; }
        public int? CustomerID { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? ApplicationNumber { get; set; }
        public DateTime? filingDate { get; set; }
        public string? ClientRefNo { get; set; }
        public string? OurRefNo { get; set; }
        public string? OfficialFilingReceiptSupporting { get; set; }
        public DateTime? WorkDeliveryDateOrMonth { get; set; }
        public string? PurchaseCurrency { get; set; }

        // tab 2
        public int? ProfessionalFeeAmt { get; set; }
        public int? GovtOrOfficialFeeAmt { get; set; }
        public int? OtherChargesAmt { get; set; }
        public int? DiscountAmt { get; set; }
        public int? DiscountCreditNoteAmt { get; set; }
        public int? TotalAmount { get; set; }

        // Tab 3
        //public DateTime? PaymentDate { get; set; }
        //public int? BankID { get; set; }
        //public string? OWRMNo1 { get; set; }
        //public string? OWRMNo2 { get; set; }
        //public string? PaymentCurrency { get; set; }
        //public int? PaymentAmount { get; set; }

        // Tab 4
        public string? CustomerPONo { get; set; }
        public DateTime? PODate { get; set; }
        public int? POValueInclusiveTaxes { get; set; }
        public string? saleCurrency { get; set; }

        [Column("PostedInTally")]
        public string? postedInTally { get; set; }

        [Column("PATENT_NO")]
        public string? PatentNo { get; set; }

        [Column("Credit_NOTE_NO")]
        public string? CreditNoteNo { get; set; }

        [Column("Credit_NOTE_DATE")]
        public DateTime? CreditNoteDate { get; set; }

        [Column("Credit_NOTE_REF_NO")]
        public string? CreditNoteRefNO { get; set; }



        public VendorEntity? VendorEntity { get; set; }
        public CustomerEntity? CustomerEntity { get; set; }
        public ICollection<VendorInvoiceFeesEntity>? FeeDetails { get; set; }
        public ICollection<VendorSalesInvoiceEntity>? SalesInvoiceDetails { get; set; }
        public ICollection<VendorPaymentInvoiceEntity>? PaymentInvoiceDetails { get; set; }
        public ICollection<VendorApplicantNamesEntity>? VendorApplicantNames { get; set; }
    }
}
