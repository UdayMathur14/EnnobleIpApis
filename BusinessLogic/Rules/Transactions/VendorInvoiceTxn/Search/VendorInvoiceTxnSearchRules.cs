using DataAccess.Domain.Masters.VendorInvoiceTxn;

namespace BusinessLogic.Rules.Masters.VendorInvoiceTxn.Search
{
    public partial class VendorInvoiceTxnSearchRules : RuleBase<VendorInvoiceTxnSearchRules>
    {
        public VendorInvoiceTxnSearchRules(VendorInvoiceTxnSearchRequestEntity VendorInvoiceTxnSearchRequestEntity, string? offset, string? count)
        {
            this.VendorInvoiceTxnSearchRequestEntity = VendorInvoiceTxnSearchRequestEntity;
            this.Offset = offset;
            this.Count = count;
        }

        private VendorInvoiceTxnSearchRequestEntity VendorInvoiceTxnSearchRequestEntity { get; }
        private string? Offset { get; set; }
        private string? Count { get; set; }
    }
}
