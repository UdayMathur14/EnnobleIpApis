using DataAccess.Domain.Masters.Customer;
using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Transactions.VendorInvoiceTxn;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain.Masters.VendorInvoiceTxn
{
    [Table("VENDOR_INVOICE_TXN")]
    public class VendorInvoiceTxnEntity :EntityBase
    {
        public int? VendorID { get; set; }

        public DateTime? InvoiceDate { get; set; }

        [MaxLength(20)]
        public string? FY { get; set; }

        [MaxLength(100)]
        public string? ClientInvoiceNo { get; set; }

        public DateTime? DueDateAsPerInvoice { get; set; }

        public int? CreditDaysAsPerContract { get; set; }

        public int? CustomerID { get; set; }

        public string? Description { get; set; }

        [MaxLength(500)]
        public string? Title { get; set; }

        [MaxLength(100)]
        public string? ApplicationNumber { get; set; }
        public DateTime? FillingDate { get; set; }

        [MaxLength(100)]
        public string? ClientRefNo { get; set; }

        [MaxLength(100)]
        public string? OurRefNo { get; set; }

        [MaxLength(20)]
        public bool? OfficialFilingReceiptSupporting { get; set; }

        [MaxLength(50)]
        public string? WorkDeliveryDateOrMonth { get; set; }

        public string? CurrencyPID { get; set; }

        public int? ProfessionalFeeAmt { get; set; }
        public int? GovtOrOfficialFeeAmt { get; set; }
        public int? OtherChargesAmt { get; set; }
        public int? DiscountAmt { get; set; }
        public int? DiscountCreditNoteAmt { get; set; }
        public int? TotalAmount { get; set; }


        public DateTime? PaymentDate { get; set; }
        public int? BankID { get; set; }

        [MaxLength(100)]
        public string? OWRMNo1 { get; set; }
        public string? OWRMNo2 { get; set; }
        public string? Currency2 { get; set; }
        public string? PaymentAmount { get; set; }



        [MaxLength(100)]
        public string? CustomerPONo { get; set; }

        public DateTime? PODate { get; set; }

        public int? POValueInclusiveTaxes { get; set; }
        public string? ProfessionalFeeInvoiceNo { get; set; }
        public string? Currency3 { get; set; }
        public int? ProfessionalFeeInvoiceAmount { get; set; }
        public string? GovtFeesInvoiceNo { get; set; }
        public string? OurInvoiceNo { get; set; }
        public int? InvoiceAmount { get; set; }

        public string? GovtFeeInvoiceNo { get; set; }
        public int? OfficialFeeInvAmount { get; set; }
        public int? EstimateNoProfFee { get; set; }
        public int? EstimateNoGovtFee { get; set; }
        public string? Remarks { get; set; }
        public string? PostedInTally { get; set; }
        public string? Status { get; set; }
        public int? TotalAmt { get; set; }

        public VendorEntity? VendorEntity { get; set; }
        public CustomerEntity? CustomerEntity { get; set; }
        public List<VendorInvoiceFeesEntity>? FeeDetails { get; set; }
    }
}
