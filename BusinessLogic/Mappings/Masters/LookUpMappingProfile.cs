using AutoMapper;
using DataAccess.Domain.Masters;
using DataAccess.Domain.Masters.LookUp;
using DataAccess.Domain.Masters.LookUpType;
using Models.RequestModels.Masters;
using Models.ResponseModels;
using Models.ResponseModels.Masters;

namespace BusinessLogic.Mappings.Masters
{
    public class LookUpMappingProfile : Profile
    {

        public LookUpMappingProfile()
        {
            CreateMap<LookUpSearchRequestModel, LookUpSearchRequestEntity>();

            CreateMap<LookUpEntity, LookUpReadResponseModel>()
                .ForMember(dest => dest.LookUpType, opt => opt.MapFrom(src => src.LookUpType));

            CreateMap<LookUpTypeEntity, CommonNestedResponseModel>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<LookUpSearchResponseEntity, LookUpSearchResponse>(); 
            
            CreateMap<LookUpRequestModel, LookUpRequestEntity >();

            CreateMap<LookUpTypeEntity, CommonNestedResponseModel>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<LookUpEntity, LookUpSearchResponse>();
               

            CreateMap<LookUpRequestModel, LookUpEntity>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ActionBy))
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => src.ActionBy));

            CreateMap<LookupUpdateRequestModel, LookUpEntity>()
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => src.ActionBy));


        }
    }
}
