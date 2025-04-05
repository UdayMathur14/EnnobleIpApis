using FluentValidation;
using Models.RequestModels.Masters.LookUpType;
using Utilities.Constants;


namespace Models.ModelValidators.Masters
{
    public class LookupTypeRequestModelValidator : AbstractValidator<LookUpTypeRequestModel>
    {
        public LookupTypeRequestModelValidator()
        {
            this.RuleLevelCascadeMode = CascadeMode.Stop;
            this.RuleFor(x => x.Type).NotEmpty().NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidTypeId.Description);
            this.RuleFor(x => x.Description).NotEmpty()
                .MaximumLength(255).WithMessage(Messages.InvalidDescription.Description);
        }
    }
}
