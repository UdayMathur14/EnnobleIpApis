using Models.ResponseModels.BaseResponseSetup;
using Models.ResponseModels.VendorInvoiceReport.VendorInvoiceReport;

namespace Models.ResponseModels.Masters.VendorInvoiceReport
{
    public class VendorInvoiceReportSearchResponse : SearchResponseBase<VendorInvoiceReportReadResponseModel>
    {
        public List<VendorInvoiceReportReadResponseModel> VendorInvoiceReports => base.Results;
    }
}
