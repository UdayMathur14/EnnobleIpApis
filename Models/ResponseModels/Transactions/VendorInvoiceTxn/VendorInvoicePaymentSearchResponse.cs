using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Masters.Bank;
using Models.ResponseModels.Masters.Customer;
using Models.ResponseModels.Masters.Vendor;

namespace Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn
{
    public class VendorInvoicePaymentSearchResponse : BaseResponseModel
    {
        public int InvoiceId { get; set; }
        public string ClientInvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal BalanceAmount { get; set; }
        public string VendorName { get; set; }
    }

}
