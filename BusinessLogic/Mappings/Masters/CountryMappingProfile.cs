using AutoMapper;
using DataAccess.Domain.Masters.Country;
using DataAccess.Domain.Masters.LookUp;
using Models.RequestModels.Masters.Country;
using Models.ResponseModels;
using Models.ResponseModels.Masters.Country;

namespace BusinessLogic.Mappings.Masters
{
    public class CountryMappingProfile : Profile
    {
      
        public CountryMappingProfile()
        {
            CreateMap<CountrySearchRequestModel, CountrySearchRequestEntity>();
            CreateMap<CountryEntity, CountryReadResponseModel>();

            CreateMap<CountrySearchResponseEntity, CountrySearchResponse>();
            CreateMap<CountryRequestModel, CountryRequestEntity>();
            CreateMap<CountryEntity, CountrySearchResponse>();
            CreateMap<CountryRequestModel, CountryEntity>()
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => src.ActionBy));

            CreateMap<LookUpEntity, CommonNestedResponseModel>();

        }
    }
}
