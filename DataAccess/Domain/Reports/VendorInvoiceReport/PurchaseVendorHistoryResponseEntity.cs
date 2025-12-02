using DataAccess.Domain.Masters.VendorInvoiceTxn;
using Models.ResponseModels.BaseResponseSetup;
using Models.ResponseModels.Reports.VendorInvoiceReport;

namespace DataAccess.Domain.Reports.VendorInvoiceReport
{
    public class PurchaseVendorHistoryResponseEntity
    {
        public IEnumerable<VendorPurchaseAmountReadResponseModel>? VendorPurchaseReports { get; set; } = new List<VendorPurchaseAmountReadResponseModel>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
