using Models.ResponseModels.BaseResponseSetup;
namespace DataAccess.Domain.Masters.Bank
{
    public class BankSearchResponseEntity
    {
        public IEnumerable<BankEntity>? Banks { get; set; } = new List<BankEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
