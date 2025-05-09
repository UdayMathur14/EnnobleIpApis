using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceTxnRequestModel
    {
        public int? SNo { get; set; }
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
        public string? ClientRefNo { get; set; }
        public string? OurRefNo { get; set; }
        public string? OfficialFilingReceiptSupporting { get; set; }
        public string? WorkDeliveryDateOrMonth { get; set; }
        public int? CurrencyPID { get; set; }
        public int? ProfessionalFeeAmt { get; set; }
        public int? GovtOrOfficialFeeAmt { get; set; }
        public int? OtherChargesAmt { get; set; }
        public int? DiscountAmt { get; set; }
        public int? DiscountCreditNoteAmt { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? BankID { get; set; }
        public string? OWRMNo { get; set; }
        public string? CustomerPONo { get; set; }
        public DateTime? PODate { get; set; }
        public int? POValueInclusiveTaxes { get; set; }
        public string? OurInvoiceNo { get; set; }
        public int? CurrencySID { get; set; }
        public int? InvoiceAmt { get; set; }
        public string? GovtFeeInvoiceNo { get; set; }
        public int? OfficialFeeInvAmount { get; set; }
        public string? EstimateNoProfFee { get; set; }
        public string? EstimateNoGovtFee { get; set; }
        public string? Remarks { get; set; }
        public string? PostedInTally { get; set; }
    }

}
