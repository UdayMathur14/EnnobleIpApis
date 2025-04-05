using BusinessLogic.Rules.Exceptions;
using Utilities;
using Utilities.Constants;

namespace BusinessLogic.Rules.Master.LookUp
{
    public partial class LookUpSearchRules
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

            this.LookUpSearchRequestEntity.Offset = intoffSet;
        }
    }
}
