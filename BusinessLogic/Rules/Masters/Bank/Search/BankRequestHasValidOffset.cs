using BusinessLogic.Rules.Exceptions;
using Utilities;
using Utilities.Constants;

namespace BusinessLogic.Rules.Master.Bank.Search
{
    public partial class BankSearchRules
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

            this.BankSearchRequestEntity.Offset = intoffSet;
        }
    }
}
