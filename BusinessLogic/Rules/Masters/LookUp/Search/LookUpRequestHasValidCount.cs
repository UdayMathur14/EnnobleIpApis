using BusinessLogic.Rules.Exceptions;
using Utilities.Constants;

namespace BusinessLogic.Rules.Master.LookUp
{
    public partial class LookUpSearchRules
    {
        public void RequestHasValidCount()
        {
            if (!int.TryParse(this.Count, out var intCount) || intCount < 0)
            {
                throw new RuleException(
                    Messages.InvalidCount.Description,
                    Messages.InvalidCount.Element,
                    this.Count,
                    Codes.InvalidCount,
                    Utilities.Category.Warning
                    );
            }

            this.LookUpSearchRequestEntity.Count = intCount;
        }
    }
}
