using Models.ResponseModels.BaseResponseSetup;
using Models.ResponseModels.Reports.VendorInvoiceReport;
using Models.ResponseModels.VendorInvoiceReport.VendorInvoiceReport;
using Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn;

namespace Models.ResponseModels.Masters.VendorInvoiceReport
{
    public class VendorInvoiceReportSearchResponse : SearchResponseBase<VendorInvoiceTxnReadResponseModel>
    {
        public List<VendorInvoiceTxnReadResponseModel> VendorInvoiceReport => base.Results;
    }
}
