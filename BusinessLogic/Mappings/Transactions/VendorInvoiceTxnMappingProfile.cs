using AutoMapper;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Transactions.VendorInvoiceTxn;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn;

namespace BusinessLogic.Mappings.VendorInvoiceTxns
{
    public class VendorInvoiceTxnMappingProfile : Profile
    {
        public VendorInvoiceTxnMappingProfile()
        {
            CreateMap<VendorInvoiceTxnSearchRequestModel, VendorInvoiceTxnSearchRequestEntity>();
            CreateMap<VendorInvoiceTxnSearchResponseEntity, VendorInvoiceTxnSearchResponse>();
            
            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnSearchResponse>();
            
            CreateMap<VendorInvoiceTxnUpdateRequestModel, VendorInvoiceTxnEntity>();

            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnReadResponseModel>();

            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnRequestModel>();

            CreateMap<VendorInvoiceTxnRequestModel, VendorInvoiceTxnEntity>()
                .ForMember(dest => dest.FeeDetails, opt => opt.MapFrom(src => src.feeDetails));

            CreateMap<FessList, VendorInvoiceFeesEntity>();

            CreateMap<Models.RequestModels.Masters.VendorInvoiceTxn.FessList, DataAccess.Domain.Transactions.VendorInvoiceTxn.VendorInvoiceFeesEntity>();

            CreateMap<Models.RequestModels.Masters.VendorInvoiceTxn.VendorInvoiceTxnRequestModel, DataAccess.Domain.Masters.VendorInvoiceTxn.VendorInvoiceTxnEntity>();

        }
    }
}
