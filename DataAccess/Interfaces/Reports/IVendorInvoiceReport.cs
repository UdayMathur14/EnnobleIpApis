using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Masters.VendorInvoiceTxn;

namespace DataAccess.Interfaces.VendorInvoiceReport
{
    public interface IVendorInvoiceReportRepository : IRepository<VendorInvoiceTxnEntity>
    {
        Task<VendorInvoiceReportSearchResponseEntity> SearchVendorInvoiceReportAsync(VendorInvoiceReportSearchRequestEntity request);
    }
}
