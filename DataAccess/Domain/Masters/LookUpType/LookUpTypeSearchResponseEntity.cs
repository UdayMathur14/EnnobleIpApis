using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.LookUpType
{
    public class LookUpTypeSearchResponseEntity
    {
        public IEnumerable<LookUpTypeEntity>? LookUpTypes { get; set; } = new List<LookUpTypeEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
    }
}
