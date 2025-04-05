using DataAccess.Domain.Masters.Bank;

namespace BusinessLogic.Rules.Master.Bank.Search
{
    public partial class BankSearchRules : RuleBase<BankSearchRules>
    {       
        public BankSearchRules(BankSearchRequestEntity bankSearchRequestEntity, string? offset, string? count)
        {
            this.BankSearchRequestEntity = bankSearchRequestEntity;
            this.Offset = offset;
            this.Count = count;
        }

        private BankSearchRequestEntity BankSearchRequestEntity { get; }
        private string? Offset { get; set; }
        private string? Count { get; set; }
    }
}
