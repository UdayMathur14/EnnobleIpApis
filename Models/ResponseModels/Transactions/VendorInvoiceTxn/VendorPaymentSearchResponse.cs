using Models.ResponseModels.BaseResponseSetup;
using Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn;

namespace Models.ResponseModels.Masters.VendorInvoiceTxn
{
    public class VendorPaymentSearchResponse : SearchResponseBase<VendorInvoicePaymentSearchResponse>
    {
        public List<VendorInvoicePaymentSearchResponse> VendorInvoiceTxns => base.Results;
    }
}
