using BusinessLogic.Rules.Exceptions;
using Utilities;
using Utilities.Constants;

namespace BusinessLogic.Rules.Master.Country
{
    public partial class CountrySearchRules
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
                    Category.Warning
                    );
            }

            this.CountrySearchRequestEntity.Count = intCount;
        }
    }
}
