using AutoMapper;
using DataAccess.Domain.Masters.Vendor;
using Models.RequestModels.Masters.Vendor;
using Models.ResponseModels.Masters.Vendor;

namespace BusinessLogic.Mappings.Masters
{
    public class VendorMappingProfile : Profile
    {
        public VendorMappingProfile()
        {
            CreateMap<VendorSearchRequestModel, VendorSearchRequestEntity>();
            CreateMap<VendorSearchResponseEntity, VendorSearchResponse>();
            CreateMap<VendorRequestModel, VendorRequestEntity>();
            CreateMap<VendorEntity, VendorSearchResponse>();
            CreateMap<VendorRequestModel, VendorEntity>();
            CreateMap<VendorUpdateRequestModel, VendorEntity>();

            CreateMap<VendorEntity, VendorReadResponseModel>();
        }
    }
}
