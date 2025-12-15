using AutoMapper;
using DataAccess.Domain.Masters.Bank;
using DataAccess.Domain.Masters.Customer;
using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Reports.VendorInvoiceReport;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.RequestModels.Reports.VendorInvoiceReport;
using Models.ResponseModels.Masters.Bank;
using Models.ResponseModels.Masters.Customer;
using Models.ResponseModels.Masters.Vendor;
using Models.ResponseModels.Masters.VendorInvoiceReport;
using Models.ResponseModels.Reports.VendorInvoiceReport;

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


            CreateMap<VendorPurchaseRequestModel, VendorInvoiceReportSearchRequestEntity>();
            CreateMap<PurchaseVendorHistoryResponseEntity, VendorPurchaseReportSearchResponse>();


            CreateMap<VendorInvoiceReportRequestModel, VendorInvoiceReportSearchRequestEntity>();
            CreateMap<VendorInvoiceReportSearchResponseEntity, VendorInvoiceReportSearchResponse>();





        }



    }
}
