using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceTxnRequestModel
    {
        // Tab 1
        public int? VendorID { get; set; }                  // vendorId
        public DateTime? InvoiceDate { get; set; }          // invoiceDate
        public string? FY { get; set; }                     // fy
        public string? ClientInvoiceNo { get; set; }        // clientInvoiceNo
        public DateTime? DueDateAsPerInvoice { get; set; }  // dueDateAsPerInvoice
        public int? CreditDaysAsPerContract { get; set; }   // creditDaysAsPerContract
        public int? CustomerID { get; set; }                // customerId
        public string? Description { get; set; }            // description
        public string? Title { get; set; }                  // title
        public string? ApplicationNumber { get; set; }      // applicationNumber
        public DateTime? FillingDate { get; set; }          // fillingDate
        public string? ClientRefNo { get; set; }            // clientRefNo
        public string? OurRefNo { get; set; }               // ourRefNo
        public bool? OfficialFilingReceiptSupporting { get; set; } // officialFilingReceiptSupporting
        public DateTime? WorkDeliveryDateOrMonth { get; set; }          // workDeliveryDateOrMonth
        public string? CurrencyPID { get; set; }               // currencyPID

        // Totals (tab1 but calculated)
        public int? ProfessionalFeeAmt { get; set; }        // professionalFeeAmt
        public int? GovtOrOfficialFeeAmt { get; set; }      // govtOrOfficialFeeAmt
        public int? OtherChargesAmt { get; set; }           // otherChargesAmt
        public int? DiscountAmt { get; set; }               // discountAmt
        public int? DiscountCreditNoteAmt { get; set; }
        public int? TotalAmount { get; set; }  // discountCreditNoteAmt

        // Tab 2
        public DateTime? PaymentDate { get; set; }          // paymentDate
        public int? BankID { get; set; }                    // bankID
        public string? OWRMNo { get; set; }                 // owrmNo
        public string? OWRMNo2 { get; set; }                // owrmNo2
        public string? Currency2 { get; set; }              // currency2
        public int? PaymentAmount { get; set; }             // paymentAmount

        // Tab 4
        public string? CustomerPONo { get; set; }           // customerPONo
        public DateTime? PODate { get; set; }               // poDate
        public int? POValueInclusiveTaxes { get; set; }     // poValueInclusiveTaxes
        public string? ProfessionalFeeInvoiceNo { get; set; }   // professionalFeeInvoiceNo
        public string? Currency3 { get; set; }              // currency3
        public int? ProfessionalFeeInvoiceAmount { get; set; }   // professionalFeeInvoiceAmount
        public string? GovtFeesInvoiceNo { get; set; }      // govtFeesInvoiceNo
        public string? OurInvoiceNo { get; set; }           // ourInvoiceNo
        public int? InvoiceAmount { get; set; }             // invoiceAmount

        public string? GovtFeeInvoiceNo { get; set; }       // govtFeeInvoiceNo
        public int? OfficialFeeInvAmount { get; set; }      // officialFeeInvoiceAmount
        public int? EstimateNoProfFee { get; set; }      // estimateNoProfFee
        public int? EstimateNoGovtFee { get; set; }      // estimateNoGovtFee
        public string? Remarks { get; set; }                // remarks
        public string? PostedInTally { get; set; }          // postedInTally

        public string? Status { get; set; }                 // status (used in form)

        // PartDetails (List to hold multiple parts)
        public List<FeeDetails>? FeeDetails { get; set; }  // partdetails

        // Optional Total Amount (for display/calculated)
        public int? TotalAmt { get; set; }                  // TotalAmt
    }

    // Assuming a structure for PartDetail if needed
    public class FeeDetails
    {
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public int? Rate { get; set; }
        public int? Amount { get; set; }
    }


}
