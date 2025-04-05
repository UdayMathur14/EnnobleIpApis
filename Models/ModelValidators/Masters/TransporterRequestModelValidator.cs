using FluentValidation;
using Models.RequestModels.Masters.Bank;
using Utilities;
using Utilities.Constants;

namespace Models.ModelValidators.Masters
{
    public class BankRequestModelValidator : AbstractValidator<BankUpdateRequestModel>
    {
        public BankRequestModelValidator()
        {
            this.RuleLevelCascadeMode = CascadeMode.Stop;

            this.RuleFor(x => x.BankContactNo).NotEmpty()
                .MaximumLength(12)
                .WithMessage(Messages.InvalidContactNo.Description);

            this.RuleFor(x => x.BankEmailId).NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress()
                .WithMessage(Messages.InvalidEmailId.Description);

            this.RuleFor(x => x.ActionBy)
                .NotNull()
                .WithMessage(Messages.InvalidNumber.Description);

            this.RuleFor(x => x.Status).NotEmpty().IsEnumName(typeof(Status), caseSensitive: false).WithMessage(Messages.InvalidStatus.Description);
        }
    }

    
}