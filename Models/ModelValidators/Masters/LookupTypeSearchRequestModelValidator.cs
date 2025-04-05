using FluentValidation;
using Models.RequestModels.Masters.LookUpType;
using Utilities.Constants;

namespace Models.ModelValidators.Masters
{
    public class LookupTypeSearchRequestModelValidator : AbstractValidator<LookUpTypeSearchRequestModel>
    {
        public LookupTypeSearchRequestModelValidator()
        {
            this.RuleLevelCascadeMode = CascadeMode.Stop;
            //this.RuleFor(x => x.Type).NotEmpty()
            //    .MaximumLength(50);
        }
    }
}
