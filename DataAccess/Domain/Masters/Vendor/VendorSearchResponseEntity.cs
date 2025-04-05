using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.Vendor
{
    public class VendorSearchResponseEntity
    {
        public IEnumerable<VendorEntity>? Vendors { get; set; } = new List<VendorEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
