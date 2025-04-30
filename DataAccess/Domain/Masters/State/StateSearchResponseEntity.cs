using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.State
{
    public class StateSearchResponseEntity
    {
        public IEnumerable<StateEntity>? States { get; set; } = new List<StateEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
