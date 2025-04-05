using DataAccess.Domain.Masters.LookUp;

namespace BusinessLogic.Rules.Master.LookUp
{
    public partial class LookUpSearchRules : RuleBase<LookUpSearchRules>
    {
        public LookUpSearchRules(LookUpSearchRequestEntity lookUpSearchRequestEntity, string? offset, string? count)
        {
            this.LookUpSearchRequestEntity = lookUpSearchRequestEntity;
            this.Offset = offset;
            this.Count = count;
        }

        private LookUpSearchRequestEntity LookUpSearchRequestEntity { get; }
        private string? Offset { get; set; }
        private string? Count { get; set; }
    }
}
