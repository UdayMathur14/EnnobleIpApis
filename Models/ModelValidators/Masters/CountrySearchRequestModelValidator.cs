using FluentValidation;
using Models.RequestModels.Masters.Country;

namespace Models.ModelValidators.Masters
{
    public class CountrySearchRequestModelValidator : AbstractValidator<CountrySearchRequestModel>
    {
        public CountrySearchRequestModelValidator()
        {
            this.RuleLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
