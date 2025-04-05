using DataAccess.Domain.Masters.Customer;

namespace BusinessLogic.Rules.Master.Customer
{
    public partial class CustomerSearchRules : RuleBase<CustomerSearchRules>
    {
        public CustomerSearchRules(CustomerSearchRequestEntity customerSearchRequestEntity, string? offset, string? count)
        {
            this.CustomerSearchRequestEntity = customerSearchRequestEntity;
            this.Offset = offset;
            this.Count = count;
        }

        private CustomerSearchRequestEntity CustomerSearchRequestEntity { get; }
        private string? Offset { get; set; }
        private string? Count { get; set; }
    }
}
