using AutoMapper;
using DataAccess.Domain.Masters.Bank;
using DataAccess.Domain.Masters.Customer;
using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Masters.Bank;
using Models.ResponseModels.Masters.Customer;
using Models.ResponseModels.Masters.Vendor;

namespace BusinessLogic.Mappings.VendorInvoiceReports
{
    public class VendorInvoiceReportMappingProfile : Profile
    {
        public VendorInvoiceReportMappingProfile()
        {
            CreateMap<VendorInvoiceReportRequestModel, VendorInvoiceReportSearchRequestEntity>();
            // 👥 Master Entities to Read Models
            CreateMap<VendorEntity, VendorReadResponseModel>();
            CreateMap<CustomerEntity, CustomerReadResponseModel>();
            CreateMap<BankEntity, BankReadResponseModel>();

        }



    }
}
