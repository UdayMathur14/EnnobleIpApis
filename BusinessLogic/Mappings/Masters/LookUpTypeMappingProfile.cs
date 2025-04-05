using AutoMapper;
using DataAccess.Domain.Masters.LookUpType;
using Models.RequestModels.Masters.LookUpType;
using Models.ResponseModels.Masters.LookUpType;

namespace BusinessLogic.Mappings.Masters
{
    public class LookUpTypeMappingProfile : Profile
    {

        public LookUpTypeMappingProfile()
        {
            CreateMap<LookUpTypeSearchRequestModel, LookUpTypeSearchRequestEntity>();
            CreateMap<LookUpTypeSearchResponseEntity, LookUpTypeSearchResponse>();
            CreateMap<LookUpTypeRequestModel, LookUpTypeRequestEntity>();
            CreateMap<LookUpTypeEntity, LookUpTypeSearchResponse>();
            CreateMap<LookUpTypeRequestModel, LookUpTypeEntity>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ActionBy))
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => src.ActionBy));
            CreateMap<LookupTypeUpdateRequestModel, LookUpTypeEntity>()
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => src.ActionBy));

            CreateMap<LookUpTypeEntity, LookUpTypeReadResponseModel>();

        }
        
    }
}
