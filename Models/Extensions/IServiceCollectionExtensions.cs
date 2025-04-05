using DataAccess.Domain.Masters;
using DataAccess.Domain.Masters.Country;
using DataAccess.Domain.Masters.Customer;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Models.ModelValidators.Masters;
using Models.RequestModels.Masters;
using Models.RequestModels.Masters.Bank;
using Models.RequestModels.Masters.Country;
using Models.RequestModels.Masters.LookUpType;

namespace ServiceFreight.Models.Extensions
{

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddModelValidators(this IServiceCollection services)
        {
            #region Masters

            #region Lookup Master
            services.AddScoped<IValidator<LookUpSearchRequestModel>, LookupSearchRequestModelValidator>();
            services.AddScoped<IValidator<LookUpRequestModel>, LookUpRequestModelValidator>();
            services.AddScoped<IValidator<LookupUpdateRequestModel>, LookupUpdateRequestModelValidator>();
            services.AddScoped<IValidator<LookUpTypeSearchRequestModel>, LookupTypeSearchRequestModelValidator>();
            services.AddScoped<IValidator<LookupTypeUpdateRequestModel>, LookUpTypeUpdateRequestModelValidator>();
            services.AddScoped<IValidator<LookUpTypeRequestModel>, LookupTypeRequestModelValidator>();
            #endregion


            #region Customer
            services.AddScoped<IValidator<CustomerRequestModel>, CustomerRequestModelValidator>();
            #endregion

            #region Bank Master
            //services.AddScoped<IValidator<BankSearchRequestModel>, BankSearchRequestModelValidator>();
            services.AddScoped<IValidator<BankUpdateRequestModel>, BankRequestModelValidator>();
            #endregion

            #region Country Master
            services.AddScoped<IValidator<CountryRequestModel>, CountryRequestModelValidator>();
            services.AddScoped<IValidator<CountrySearchRequestModel>, CountrySearchRequestModelValidator>();
            #endregion
            #endregion // ✅ This closes the "Masters" region properly



            return services;
        }
    }


}
