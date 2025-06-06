using DataAccess.Domain.Masters.Customer;
using Models.RequestModels.Masters.Vendor;
using Models.RequestModels.Masters.VendorInvoiceTxn;

namespace Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn
{
    public class VendorInvoiceTxnReadResponseModel : BaseResponseModel
    {
        public int? VendorID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? FY { get; set; }
        public string? ClientInvoiceNo { get; set; }
        public DateTime? DueDateAsPerInvoice { get; set; }
        public int? CreditDaysAsPerContract { get; set; }
        public int? CustomerID { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? ApplicationNumber { get; set; }
        public DateTime? FillingDate { get; set; }
        public string? ClientRefNo { get; set; }
        public string? OurRefNo { get; set; }
        public bool? OfficialFilingReceiptSupporting { get; set; }
        public DateTime? WorkDeliveryDateOrMonth { get; set; }
        public string? CurrencyPID { get; set; }

        // Totals (tab1 but calculated)
        public int? ProfessionalFeeAmt { get; set; }
        public int? GovtOrOfficialFeeAmt { get; set; }
        public int? OtherChargesAmt { get; set; }
        public int? DiscountAmt { get; set; }
        public int? DiscountCreditNoteAmt { get; set; }
        public int? TotalAmount { get; set; }

        // Tab 2
        public DateTime? PaymentDate { get; set; }
        public int? BankID { get; set; }
        public string? OWRMNo1 { get; set; }
        public string? OWRMNo2 { get; set; }
        public string? Currency2 { get; set; }
        public int? PaymentAmount { get; set; }

        // Tab 4
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
        public List<FessList>? feeDetails { get; set; }
        public int? TotalAmt { get; set; }
        //public VendorRequestModel? VendorEntity { get; set; }
        //public CustomerRequestModel? CustomerEntity { get; set; }
    }

}
