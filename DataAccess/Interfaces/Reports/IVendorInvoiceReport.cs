using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Masters.VendorInvoiceTxn;

namespace DataAccess.Interfaces.VendorInvoiceReport
{
    public interface IVendorInvoiceReportRepository : IRepository<VendorInvoiceTxnEntity>
    {
        Task<VendorInvoiceReportSearchResponseEntity> SearchVendorInvoiceReportAsync(VendorInvoiceReportSearchRequestEntity request);
        Task<VendorInvoiceTxnSearchResponseEntity> SearchVendorInvoiceTxnAsync1(VendorInvoiceTxnSearchRequestEntity request);
        Task<VendorInvoiceReportSearchResponseEntity> SearchSaleInvoiceReportAsync(VendorInvoiceReportSearchRequestEntity request);
        Task<VendorInvoiceReportSearchResponseEntity> SearchCustomerInvoiceTotalReportAsync(VendorInvoiceReportSearchRequestEntity request);
        Task<VendorInvoiceReportSearchResponseEntity> SearchVendorPurchaseAsync(VendorInvoiceReportSearchRequestEntity request);
        Task<VendorSearchResponseEntity> SearchVendorAsync(VendorSearchRequestEntity request);
    }
}
