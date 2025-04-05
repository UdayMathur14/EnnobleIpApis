using FluentValidation;
using Models.RequestModels.Masters;

namespace Models.ModelValidators.Masters
{
    public class LookupSearchRequestModelValidator: AbstractValidator<LookUpSearchRequestModel>
    {
        public LookupSearchRequestModelValidator()
        {
            this.RuleLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
