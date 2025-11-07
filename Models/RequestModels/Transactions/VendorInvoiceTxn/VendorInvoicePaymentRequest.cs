using Models.RequestModels.Masters.VendorInvoiceTxn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Transactions.VendorInvoiceTxn
{
    //public class VendorInvoicePaymentRequest
    //{
    //    public List<int>? VendorInvoiceIds { get; set; }  
    //    public List<PaymentInvoiceDetailList>? PaymentDetails { get; set; }
    //    public string? paymentMode { get; set; }
    //}

    public class VendorInvoicePaymentRequest
    {
        // These IDs might still be useful for initial validation/lookup
        public List<int>? VendorInvoiceIds { get; set; }

        // This list will contain ONE item for Full Payment, or N items for Partial Payment.
        public List<PaymentInvoiceDetailListNew>? PaymentDetails { get; set; }
    }

    public class PaymentInvoiceDetailListNew
    {
        // The Invoice ID must be explicitly sent from the frontend for Partial Payments
        public int? VendorInvoiceId { get; set; }

        // These fields are common to both types
        public DateTime? paymentDate { get; set; }
        public int? bankID { get; set; }
        public string? oWRMNo1 { get; set; }
        public string? paymentCurrency { get; set; }

        // Full Payment fields (used for distribution calculation)
        // For Partial Payment, rate is usually 0 (or the individual payment amount) and bankcharges is 0 (or individual charge)
        public decimal? rate { get; set; }        // This is the Forex Amount (Total for Full, or Individual Amount for Partial)
        public decimal? quantity { get; set; }    // Rate Of Exchange (ROE) - Common for both
        public decimal? bankcharges { get; set; } // Total Bank Charges (for Full), or Individual Bank Charges (for Partial)

        // Calculated values (passed by frontend for Partial, or calculated here for Full)
        public decimal? calculatedBankCharges { get; set; } // Final bank charges allocated to this invoice
        public decimal? calculatedTotalINR { get; set; }    // Final INR amount for this invoice

        // **CRITICAL FLAG**: Simplifies backend logic based on frontend choice
        public bool isPartial { get; set; }
        public bool paymentstatus { get; set; }
    }

}
