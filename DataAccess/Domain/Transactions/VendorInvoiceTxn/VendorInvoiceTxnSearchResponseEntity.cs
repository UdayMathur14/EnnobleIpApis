using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceTxnSearchResponseEntity
    {
        public IEnumerable<VendorInvoiceTxnEntity>? VendorInvoiceTxn { get; set; } = new List<VendorInvoiceTxnEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
