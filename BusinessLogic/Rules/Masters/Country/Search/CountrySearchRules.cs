using DataAccess.Domain.Masters.Country;

namespace BusinessLogic.Rules.Master.Country
{
    public partial class CountrySearchRules : RuleBase<CountrySearchRules>
    {
        public CountrySearchRules(CountrySearchRequestEntity countrySearchRequestEntity, string? offset, string? count)
        {
            this.CountrySearchRequestEntity = countrySearchRequestEntity;
            this.Offset = offset;
            this.Count = count;
        }

        private CountrySearchRequestEntity CountrySearchRequestEntity { get; }
        private string? Offset { get; set; }
        private string? Count { get; set; }
    }
}
