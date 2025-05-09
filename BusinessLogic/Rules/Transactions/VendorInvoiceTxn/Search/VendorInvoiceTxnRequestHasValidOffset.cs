using BusinessLogic.Rules.Exceptions;
using Utilities;
using Utilities.Constants;

namespace BusinessLogic.Rules.Masters.VendorInvoiceTxn.Search
{
    public partial class VendorInvoiceTxnSearchRules
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

            this.VendorInvoiceTxnSearchRequestEntity.Offset = intoffSet;
        }
    }
}
