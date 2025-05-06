using DataAccess.Domain.Masters.Transaction;

namespace BusinessLogic.Rules.Masters.Transaction.Search
{
    public partial class TransactionSearchRules : RuleBase<TransactionSearchRules>
    {
        public TransactionSearchRules(TransactionSearchRequestEntity TransactionSearchRequestEntity, string? offset, string? count)
        {
            this.TransactionSearchRequestEntity = TransactionSearchRequestEntity;
            this.Offset = offset;
            this.Count = count;
        }

        private TransactionSearchRequestEntity TransactionSearchRequestEntity { get; }
        private string? Offset { get; set; }
        private string? Count { get; set; }
    }
}
