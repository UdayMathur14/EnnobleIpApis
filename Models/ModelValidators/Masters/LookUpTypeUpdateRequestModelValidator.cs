using FluentValidation;
using Models.RequestModels.Masters.LookUpType;
using Utilities;
using Utilities.Constants;

namespace Models.ModelValidators.Masters
{
    public class LookUpTypeUpdateRequestModelValidator: AbstractValidator<LookupTypeUpdateRequestModel>
    {
        public LookUpTypeUpdateRequestModelValidator()
        {
            this.RuleLevelCascadeMode = CascadeMode.Stop;
            this.RuleFor(x => x.Type).NotNull().NotEmpty()
                .MaximumLength(50).WithMessage(Messages.InvalidTypeId.Description);
            this.RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(255).WithMessage(Messages.InvalidDescription.Description);
            this.RuleFor(x => x.Status).NotEmpty().IsEnumName(typeof(Status), caseSensitive: false).WithMessage(Messages.InvalidStatus.Description);
        }
    }
}
