using Models.RequestModels.Masters.Vendor;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.RequestModels.Reports.VendorInvoiceReport;
using Models.ResponseModels.Masters.Vendor;
using Models.ResponseModels.Masters.VendorInvoiceReport;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Reports.VendorInvoiceReport;
using Utilities;

namespace BusinessLogic.Interfaces.VendorInvoiceReports
{
    public interface IVendorInvoiceReportService
    {
        Task<IResponseWrapper<VendorInvoiceReportSearchResponse>> SearchVendorInvoiceReportAsync(VendorInvoiceReportRequestModel requestModel, string? offset, string count);

        Task<IResponseWrapper<VendorInvoiceTxnSearchResponse>> SearchVendorInvoiceTxnAsync(VendorInvoiceTxnSearchRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<VendorPurchaseReportSearchResponse>> SearchVendorInvoiceTxnAsync3(VendorInvoiceTxnSearchRequestModel requestModel, string? offset, string count);

        Task<IResponseWrapper<VendorInvoiceReportSearchResponse>> SearchSaleInvoiceReportAsync(VendorInvoiceReportRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<VendorInvoiceReportSearchResponse>> SearchCustomerInvoiceTotalReportAsync(VendorInvoiceReportRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<VendorSearchResponse>> SearchVendorAsync(VendorSearchRequestModel requestModel, string? offset, string count);

        Task<IResponseWrapper<VendorPurchaseReportSearchResponse>> SearchVendorPurchaseAsync(VendorPurchaseRequestModel requestModel, string? offset, string count);

    }
}
