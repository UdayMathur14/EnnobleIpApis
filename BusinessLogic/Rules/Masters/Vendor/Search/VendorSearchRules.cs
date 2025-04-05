using DataAccess.Domain.Masters.Vendor;

namespace BusinessLogic.Rules.Masters.Vendor.Search
{
    public partial class VendorSearchRules : RuleBase<VendorSearchRules>
    {
        public VendorSearchRules(VendorSearchRequestEntity VendorSearchRequestEntity, string? offset, string? count)
        {
            this.VendorSearchRequestEntity = VendorSearchRequestEntity;
            this.Offset = offset;
            this.Count = count;
        }

        private VendorSearchRequestEntity VendorSearchRequestEntity { get; }
        private string? Offset { get; set; }
        private string? Count { get; set; }
    }
}
