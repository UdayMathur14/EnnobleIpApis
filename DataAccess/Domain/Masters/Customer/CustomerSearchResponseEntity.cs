using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.Customer
{
    public class CustomerSearchResponseEntity
    {
        public IEnumerable<CustomerEntity>? Customers { get; set; } = new List<CustomerEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
