using AutoMapper;
using DataAccess.Domain.Masters.Bank;
using DataAccess.Domain.Masters.Customer;
using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Transactions.VendorInvoiceReport;
using Models.RequestModels.Masters.VendorInvoiceReport;
using Models.ResponseModels.Masters.Bank;
using Models.ResponseModels.Masters.Customer;
using Models.ResponseModels.Masters.Vendor;
using Models.ResponseModels.Masters.VendorInvoiceReport;
using Models.ResponseModels.VendorInvoiceReport.VendorInvoiceReport;

namespace BusinessLogic.Mappings.VendorInvoiceReports
{
    public class VendorInvoiceReportMappingProfile : Profile
    {
        public VendorInvoiceReportMappingProfile()
        {

            CreateMap<VendorInvoiceFeesEntity, InvoiceFessDetailList>().ReverseMap();
            CreateMap<VendorPaymentInvoiceEntity, PaymentInvoiceDetailList>().ReverseMap();
            CreateMap<VendorApplicantNamesEntity, VendorApplicantNameList>().ReverseMap();

            // 🧾 Sales Invoice Detail Mapping
            CreateMap<VendorSalesInvoiceEntity, SaleInvoiceDetailList>().ReverseMap();
            // 🔍 Search Models
            CreateMap<VendorInvoiceReportSearchRequestModel, VendorInvoiceReportSearchRequestEntity>();

            CreateMap<VendorInvoiceReportSearchResponseEntity, VendorInvoiceReportSearchResponse>()
                .ForMember(dest => dest.VendorInvoiceReports, opt => opt.MapFrom(src => src.VendorInvoiceReport));

            // 📝 Create or Update Request → Entity
            CreateMap<VendorInvoiceReportRequestModel, VendorInvoiceReportEntity>()
                .ForMember(dest => dest.FeeDetails, opt => opt.MapFrom(src => src.invoiceFeeDetails))
                .ForMember(dest => dest.SalesInvoiceDetails, opt => opt.MapFrom(src => src.salesInvoiceDetails))
                .ForMember(dest => dest.PaymentInvoiceDetails, opt => opt.MapFrom(src => src.paymentFeeDetails))
                .ForMember(dest => dest.VendorApplicantNames, opt => opt.MapFrom(src => src.VendorApplicantNames));


            CreateMap<VendorInvoiceReportUpdateRequestModel, VendorInvoiceReportEntity>()
                 .ForMember(dest => dest.FeeDetails, opt => opt.MapFrom(src => src.invoiceFeeDetails))
                .ForMember(dest => dest.SalesInvoiceDetails, opt => opt.MapFrom(src => src.salesInvoiceDetails))
                .ForMember(dest => dest.PaymentInvoiceDetails, opt => opt.MapFrom(src => src.paymentFeeDetails))
            .ForMember(dest => dest.VendorApplicantNames, opt => opt.MapFrom(src => src.VendorApplicantNames));

            // 🔁 Reverse: Entity → RequestModel
            CreateMap<VendorInvoiceReportEntity, VendorInvoiceReportRequestModel>()
                .ForMember(dest => dest.invoiceFeeDetails, opt => opt.MapFrom(src => src.FeeDetails))
                .ForMember(dest => dest.salesInvoiceDetails, opt => opt.MapFrom(src => src.SalesInvoiceDetails))
                .ForMember(dest => dest.paymentFeeDetails, opt => opt.MapFrom(src => src.PaymentInvoiceDetails))
            .ForMember(dest => dest.VendorApplicantNames, opt => opt.MapFrom(src => src.VendorApplicantNames));



            // 📤 Entity → Read Response
            CreateMap<VendorInvoiceReportEntity, VendorInvoiceReportReadResponseModel>()
                .ForMember(dest => dest.feeDetails, opt => opt.MapFrom(src => src.FeeDetails))
                .ForMember(dest => dest.saleDetails, opt => opt.MapFrom(src => src.SalesInvoiceDetails))
                .ForMember(dest => dest.VendorDetails, opt => opt.MapFrom(src => src.VendorEntity))
                .ForMember(dest => dest.CustomerDetails, opt => opt.MapFrom(src => src.CustomerEntity)) // ✅ spelling fixed
                .ForMember(dest => dest.paymentDetails, opt => opt.MapFrom(src => src.PaymentInvoiceDetails))
            .ForMember(dest => dest.NameDetails, opt => opt.MapFrom(src => src.VendorApplicantNames));

            // 💸 Fee Details List Mapping


            // 👥 Master Entities to Read Models
            CreateMap<VendorEntity, VendorReadResponseModel>();
            CreateMap<CustomerEntity, CustomerReadResponseModel>();
            CreateMap<BankEntity, BankReadResponseModel>();

            // 🧹 Removed Redundant Mapping: VendorInvoiceReportEntity → VendorInvoiceReportSearchResponse (Not needed)

        }



    }
}
