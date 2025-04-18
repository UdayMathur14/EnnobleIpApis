using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.LookUpType
{
    public class LookUpTypeSearchResponseEntity
    {
        public IEnumerable<LookUpTypeEntity>? LookUpTypes { get; set; } = new List<LookUpTypeEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
