using AutoMapper;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
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
            CreateMap<VendorInvoiceTxnRequestModel, VendorInvoiceTxnRequestEntity>();
            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnSearchResponse>();
            CreateMap<VendorInvoiceTxnRequestModel, VendorInvoiceTxnEntity>();
            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnRequestModel>();
            CreateMap<VendorInvoiceTxnUpdateRequestModel, VendorInvoiceTxnEntity>();

            CreateMap<VendorInvoiceTxnEntity, VendorInvoiceTxnReadResponseModel>();
        }
    }
}
