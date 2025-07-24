using AutoMapper;
using DataAccess.Domain.Masters.Bank;
using DataAccess.Domain.Masters.Customer;
using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Transactions.VendorInvoiceTxn;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Masters.Bank;
using Models.ResponseModels.Masters.Customer;
using Models.ResponseModels.Masters.Vendor;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn;

namespace BusinessLogic.Mappings.VendorInvoiceTxns
{
    public class VendorInvoiceTxnMappingProfile : Profile
    {
        public VendorInvoiceTxnMappingProfile()
        {

            CreateMap<VendorInvoiceFeesEntity, InvoiceFessDetailList>().ReverseMap();

            // 🧾 Sales Invoice Detail Mapping
            CreateMap<VendorSalesInvoiceEntity, SaleInvoiceDetailList>().ReverseMap();
            // 🔍 Search Models
            CreateMap<VendorInvoiceTxnSearchRequestModel, VendorInvoiceTxnSearchRequestEntity>();

            CreateMap<VendorInvoiceTxnSearchResponseEntity, VendorInvoiceTxnSearchResponse>()
                .ForMember(dest => dest.VendorInvoiceTxns, opt => opt.MapFrom(src => src.VendorInvoiceTxn));

            // 📝 Create or Update Request → Entity
            CreateMap<VendorInvoiceTxnRequestModel, VendorInvoiceTxnEntity>()
                .ForMember(dest => dest.FeeDetails, opt => opt.MapFrom(src => src.invoiceFeeDetails))
                .ForMember(dest => dest.SalesInvoiceDetails, opt => opt.MapFrom(src => src.salesInvoiceDetails));


            CreateMap<VendorInvoiceTxnUpdateRequestModel, VendorInvoiceTxnEntity>()
                 .ForMember(dest => dest.FeeDetails, opt => opt.MapFrom(src => src.invoiceFeeDetails))
                .ForMember(dest => dest.SalesInvoiceDetails, opt => opt.MapFrom(src => src.salesInvoiceDetails));

            // 🔁 Reverse: Entity → RequestModel
            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnRequestModel>()
                .ForMember(dest => dest.invoiceFeeDetails, opt => opt.MapFrom(src => src.FeeDetails))
                .ForMember(dest => dest.salesInvoiceDetails, opt => opt.MapFrom(src => src.SalesInvoiceDetails));
                

            // 📤 Entity → Read Response
            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnReadResponseModel>()
                .ForMember(dest => dest.feeDetails, opt => opt.MapFrom(src => src.FeeDetails))
                .ForMember(dest => dest.saleDetails, opt => opt.MapFrom(src => src.SalesInvoiceDetails))
                .ForMember(dest => dest.VendorDetails, opt => opt.MapFrom(src => src.VendorEntity))
                .ForMember(dest => dest.CustomerDetails, opt => opt.MapFrom(src => src.CustomerEntity)) // ✅ spelling fixed
                .ForMember(dest => dest.BankDetails, opt => opt.MapFrom(src => src.BankEntity));

            // 💸 Fee Details List Mapping
          

            // 👥 Master Entities to Read Models
            CreateMap<VendorEntity, VendorReadResponseModel>();
            CreateMap<CustomerEntity, CustomerReadResponseModel>();
            CreateMap<BankEntity, BankReadResponseModel>();

            // 🧹 Removed Redundant Mapping: VendorInvoiceTxnEntity → VendorInvoiceTxnSearchResponse (Not needed)

        }



    }
}
