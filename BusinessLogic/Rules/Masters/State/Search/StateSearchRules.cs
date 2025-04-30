using DataAccess.Domain.Masters.State;

namespace BusinessLogic.Rules.Master.State
{
    public partial class StateSearchRules : RuleBase<StateSearchRules>
    {
        public StateSearchRules(StateSearchRequestEntity countrySearchRequestEntity, string? offset, string? count)
        {
            this.StateSearchRequestEntity = countrySearchRequestEntity;
            this.Offset = offset;
            this.Count = count;
        }

        private StateSearchRequestEntity StateSearchRequestEntity { get; }
        private string? Offset { get; set; }
        private string? Count { get; set; }
    }
}
