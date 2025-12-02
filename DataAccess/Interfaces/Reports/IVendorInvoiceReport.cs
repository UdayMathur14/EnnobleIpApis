using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Reports.VendorInvoiceReport;

namespace DataAccess.Interfaces.VendorInvoiceReport
{
    public interface IVendorInvoiceReportRepository : IRepository<VendorInvoiceTxnEntity>
    {
        Task<VendorInvoiceReportSearchResponseEntity> SearchVendorInvoiceReportAsync(VendorInvoiceReportSearchRequestEntity request);
        Task<VendorInvoiceTxnSearchResponseEntity> SearchVendorInvoiceTxnAsync1(VendorInvoiceTxnSearchRequestEntity request);
        Task<PurchaseVendorHistoryResponseEntity> SearchVendorInvoiceTxnAsync3(VendorInvoiceTxnSearchRequestEntity request);
        Task<VendorInvoiceReportSearchResponseEntity> SearchSaleInvoiceReportAsync(VendorInvoiceReportSearchRequestEntity request);
        Task<VendorInvoiceReportSearchResponseEntity> SearchCustomerInvoiceTotalReportAsync(VendorInvoiceReportSearchRequestEntity request);
        Task<PurchaseVendorHistoryResponseEntity> SearchVendorPurchaseAsync(VendorInvoiceReportSearchRequestEntity request);
        Task<VendorSearchResponseEntity> SearchVendorAsync(VendorSearchRequestEntity request);
    }
}
