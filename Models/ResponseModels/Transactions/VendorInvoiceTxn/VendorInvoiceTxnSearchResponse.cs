using Models.ResponseModels.BaseResponseSetup;
using Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn;

namespace Models.ResponseModels.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceTxnSearchResponse : SearchResponseBase<VendorInvoiceTxnReadResponseModel>
    {
        public List<VendorInvoiceTxnReadResponseModel> VendorInvoiceTxns => base.Results;
    }
}
