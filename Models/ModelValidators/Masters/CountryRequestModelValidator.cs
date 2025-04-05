using DataAccess.Domain.Masters.Country;
using FluentValidation;
using Utilities;
using Utilities.Constants;

namespace Models.ModelValidators.Masters
{
    public class CountryRequestModelValidator : AbstractValidator<CountryRequestModel>
    {
        public CountryRequestModelValidator()
        {
            this.RuleLevelCascadeMode = CascadeMode.Stop;
            this.RuleLevelCascadeMode = CascadeMode.Stop;
            this.RuleFor(x => x.ICountryId)
                .NotEmpty().WithMessage(Messages.InvalidCountry.Description);
            this.RuleFor(x => x.GlSubCategoryId)
                .NotEmpty().WithMessage(Messages.InvalidGLSubCategory.Description);
            this.RuleFor(x => x.Status).NotEmpty().IsEnumName(typeof(Status), caseSensitive: false).WithMessage(Messages.InvalidStatus.Description);
        }
    }
}
