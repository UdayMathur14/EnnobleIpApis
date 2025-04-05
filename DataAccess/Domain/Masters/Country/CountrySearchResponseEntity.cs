using Models.ResponseModels.BaseResponseSetup;

namespace DataAccess.Domain.Masters.Country
{
    public class CountrySearchResponseEntity
    {
        public IEnumerable<CountryEntity>? Countrys { get; set; } = new List<CountryEntity>();
        public PagingModel Paging { get; set; } = new PagingModel();
        public Dictionary<string, List<string>> Filters { get; set; } = new Dictionary<string, List<string>>();
    }
}
