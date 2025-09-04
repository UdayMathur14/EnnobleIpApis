using DataAccess.Domain.Masters.VendorInvoiceTxn;
using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.VendorInvoiceReport
{
    public class VendorInvoiceReportSearchResponseEntity
    {
        public IEnumerable<VendorInvoiceTxnEntity>? VendorInvoiceReport { get; set; } = new List<VendorInvoiceTxnEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
