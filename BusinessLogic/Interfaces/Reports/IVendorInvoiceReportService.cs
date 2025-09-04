using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Masters.VendorInvoiceReport;
using Utilities;

namespace BusinessLogic.Interfaces.VendorInvoiceReports
{
    public interface IVendorInvoiceReportService
    {
        Task<IResponseWrapper<VendorInvoiceReportSearchResponse>> SearchVendorInvoiceReportAsync(VendorInvoiceReportRequestModel requestModel, string? offset, string count);

    }
}
