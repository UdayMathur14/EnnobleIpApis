using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Masters.Bank;
using Models.ResponseModels.Masters.Customer;
using Models.ResponseModels.Masters.Vendor;

namespace Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn
{
    public class VendorInvoiceTxnReadResponseModel : BaseResponseModel
    {
        public int? vendorID { get; set; }
        public DateTime? invoiceDate { get; set; }
        public string? FY { get; set; }
        public string? clientInvoiceNo { get; set; }
        public DateTime? dueDateAsPerInvoice { get; set; }
        public int? creditDaysAsPerContract { get; set; }
        public DateTime? DueDateAsPerContract { get; set; } 
        public int? customerID { get; set; }
        public string? description { get; set; }
        public string? title { get; set; }
        public string? applicationNumber { get; set; }
        public DateTime? filingDate { get; set; }
        public string? clientRefNo { get; set; }
        public string? ourRefNo { get; set; }
        public string? officialFilingReceiptSupporting { get; set; }
        public DateTime? workDeliveryDateOrMonth { get; set; }
        public string? purchaseCurrency { get; set; }

        // Tab2
        public List<InvoiceFessDetailList>? invoiceFeeDetails { get; set; }
        public decimal? professionalFeeAmt { get; set; }
        public decimal? govtOrOfficialFeeAmt { get; set; }
        public decimal? otherChargesAmt { get; set; }
        public decimal? discountAmt { get; set; }
        public decimal? discountCreditNoteAmt { get; set; }
        public decimal? totalAmount { get; set; }
        public string? postedInTally { get; set; }
        public string? patentNo { get; set; }
        public string? creditNoteNo { get; set; }
        public DateTime? creditNoteDate { get; set; }
        public string? creditNoteRefNo { get; set; }
        public string? customerPONo { get; set; }
        public DateTime? pODate { get; set; }
        public decimal? pOValueInclusiveTaxes { get; set; }
        public string? saleCurrency { get; set; }
        public List<InvoiceFessDetailList>? feeDetails { get; set; }
        public List<SaleInvoiceDetailList>? saleDetails { get; set; }
        public List<PaymentInvoiceDetailList>? paymentDetails { get; set; }
        public VendorReadResponseModel? VendorDetails { get; set; }
        public CustomerReadResponseModel? CustomerDetails { get; set; }
        public List<VendorApplicantNameList>? NameDetails { get; set; }
    }

}
