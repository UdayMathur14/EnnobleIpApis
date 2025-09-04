using DataAccess.Interfaces.Masters;
using DataAccess.Interfaces.VendorInvoiceReport;
using DataAccess.Interfaces.VendorInvoiceTxn;
using DataAccess.Repositories.Masters;
using DataAccess.Repositories.VendorInvoiceReports;
using DataAccess.Repositories.VendorInvoiceTxns;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceFreight.DataAccess.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            //masters
            services.AddScoped<ILookUpTypeRepository, LookUpTypeRepository>();
            services.AddScoped<ILookUpRepository, LookUpRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();

            //transactions
            services.AddScoped<IVendorInvoiceTxnRepository, VendorInvoiceTxnRepository>();
            services.AddScoped<IVendorInvoiceReportRepository, VendorInvoiceReportRepository>();
            return services;
        }
    }
}
