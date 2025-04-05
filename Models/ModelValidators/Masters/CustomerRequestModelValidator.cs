using DataAccess.Domain.Masters.Customer;
using FluentValidation;
using Utilities;
using Utilities.Constants;

namespace Models.ModelValidators.Masters
{
    public class CustomerRequestModelValidator : AbstractValidator<CustomerRequestModel>
    {
        public CustomerRequestModelValidator()
        {
            this.RuleLevelCascadeMode = CascadeMode.Stop;

            this.RuleFor(x => x.CustomerContactNo).NotNull().NotEmpty().WithMessage(Messages.InvalidContactNo.Description);
            this.RuleFor(x => x.CustomerEmailId).NotNull().NotEmpty().WithMessage(Messages.InvalidEmailId.Description);
            this.RuleFor(x => x.Status).NotEmpty().IsEnumName(typeof(Status), caseSensitive: false).WithMessage(Messages.InvalidStatus.Description);
        }
    }
}
