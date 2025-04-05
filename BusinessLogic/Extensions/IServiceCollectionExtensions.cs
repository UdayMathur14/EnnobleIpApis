using BusinessLogic.Interfaces.Masters;
using BusinessLogic.Mappings.Masters;
using BusinessLogic.Services.Masters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceFreight.BusinessLogic.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            

            services.AddScoped<ILookUpTypeService, LookUpTypeService>();
            services.AddAutoMapper(typeof(LookUpTypeMappingProfile).Assembly);

            services.AddScoped<ILookUpService, LookUpService>();
            services.AddAutoMapper(typeof(LookUpMappingProfile).Assembly);

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddAutoMapper(typeof(CustomerMappingProfile).Assembly);

            services.AddScoped<IVendorService, VendorService>();
            services.AddAutoMapper(typeof(VendorMappingProfile).Assembly);

            services.AddScoped<IBankService, BankService>();
            services.AddAutoMapper(typeof(BankMappingProfile).Assembly);

            services.AddScoped<ICountryService, CountryService>();
            services.AddAutoMapper(typeof(CountryMappingProfile).Assembly);

            return services;
        }
    }
}
