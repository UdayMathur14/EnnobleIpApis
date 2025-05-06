using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.Transaction
{
    public class TransactionSearchResponseEntity
    {
        public IEnumerable<TransactionEntity>? Transactions { get; set; } = new List<TransactionEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
