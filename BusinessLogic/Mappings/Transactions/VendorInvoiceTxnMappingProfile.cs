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
            CreateMap<VendorInvoiceTxnSearchRequestModel, VendorInvoiceTxnSearchRequestEntity>();
            CreateMap<VendorInvoiceTxnSearchResponseEntity, VendorInvoiceTxnSearchResponse>()
                .ForMember(dest => dest.VendorInvoiceTxns, opt => opt.MapFrom(src => src.VendorInvoiceTxn)); 
            
            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnSearchResponse>();
            
            CreateMap<VendorInvoiceTxnUpdateRequestModel, VendorInvoiceTxnEntity>();

            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnRequestModel>();

            CreateMap<VendorInvoiceTxnRequestModel, VendorInvoiceTxnEntity>()
                .ForMember(dest => dest.FeeDetails, opt => opt.MapFrom(src => src.feeDetails));

            CreateMap<FessList, VendorInvoiceFeesEntity>();

            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnRequestModel>()
                .ForMember(dest => dest.feeDetails, opt => opt.MapFrom(src => src.FeeDetails));

            CreateMap<VendorInvoiceFeesEntity, FessList>(); 

            CreateMap<Models.RequestModels.Masters.VendorInvoiceTxn.FessList, DataAccess.Domain.Transactions.VendorInvoiceTxn.VendorInvoiceFeesEntity>();

            CreateMap<Models.RequestModels.Masters.VendorInvoiceTxn.VendorInvoiceTxnRequestModel, DataAccess.Domain.Masters.VendorInvoiceTxn.VendorInvoiceTxnEntity>();

            CreateMap<VendorEntity, VendorReadResponseModel>();
            CreateMap<CustomerEntity, CustomerReadResponseModel>();
            CreateMap<BankEntity, BankReadResponseModel>();

            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnReadResponseModel>()
                .ForMember(dest => dest.feeDetails, opt => opt.MapFrom(src => src.FeeDetails))
                .ForMember(dest => dest.VendorDetails, opt => opt.MapFrom(src => src.VendorEntity))
                .ForMember(dest => dest.CustomerDetials, opt => opt.MapFrom(src => src.CustomerEntity))
                .ForMember(dest => dest.BankDetails, opt => opt.MapFrom(src => src.BankEntity));

        }
    }
}
