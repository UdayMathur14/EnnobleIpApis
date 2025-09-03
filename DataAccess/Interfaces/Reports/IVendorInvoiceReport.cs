using DataAccess.Domain.Masters.VendorInvoiceReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces.VendorInvoiceReport
{
    public interface IVendorInvoiceReportRepository : IRepository<VendorInvoiceReportEntity>
    {
        Task<VendorInvoiceReportSearchResponseEntity> SearchVendorInvoiceReportAsync(VendorInvoiceReportSearchRequestEntity request);
        Task<VendorInvoiceReportEntity?> IsExistsAsync(string? code);
    }
}
