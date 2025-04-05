using DataAccess.Domain.Masters;
using FluentValidation;
using Utilities.Constants;

namespace Models.ModelValidators.Masters
{
    public class LookUpRequestModelValidator : AbstractValidator<LookUpRequestModel>
    {
        public LookUpRequestModelValidator()
        {
            this.RuleLevelCascadeMode = CascadeMode.Stop;
            this.RuleFor(x => x.TypeId).NotNull().NotEmpty().WithMessage(Messages.InvalidTypeId.Description);
            this.RuleFor(x => x.Code).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidCode.Description);
            this.RuleFor(x => x.Value).NotEmpty().MaximumLength(100).WithMessage(Messages.InvalidValue.Description);
            this.RuleFor(x => x.Description).NotEmpty().MaximumLength(255).WithMessage(Messages.InvalidDescription.Description);
        }
    }
}
