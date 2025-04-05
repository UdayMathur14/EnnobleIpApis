using BusinessLogic.Rules.Exceptions;
using Utilities;
using Utilities.Constants;

namespace BusinessLogic.Rules.Masters.Vendor.Search
{
    public partial class VendorSearchRules
    {
        public void RequestHasValidOffset()
        {
            if (!int.TryParse(this.Offset, out var intoffSet) || intoffSet < 0)
            {
                throw new RuleException(
                    Messages.InvalidOffset.Description,
                    Messages.InvalidOffset.Element,
                    this.Count,
                    Codes.InvalidOffset,
                    Category.Warning
                    );
            }

            this.VendorSearchRequestEntity.Offset = intoffSet;
        }
    }
}
