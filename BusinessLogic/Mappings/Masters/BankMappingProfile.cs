using AutoMapper;
using DataAccess.Domain.Masters.Bank;
using DataAccess.Domain.Masters.LookUp;
using Models.RequestModels.Masters.Bank;
using Models.ResponseModels;
using Models.ResponseModels.Masters.Bank;

namespace BusinessLogic.Mappings.Masters
{
    public class BankMappingProfile : Profile
    {
       
        public BankMappingProfile()
        {
            CreateMap<BankSearchRequestModel, BankSearchRequestEntity>();

            CreateMap<BankEntity, BankReadResponseModel>();
            CreateMap<BankSearchResponseEntity, BankSearchResponseModel>();
            CreateMap<BankRequestModel, BankRequestEntity>();
            CreateMap<BankRequestEntity, BankSearchResponseModel>();
            CreateMap<BankRequestModel, BankEntity>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ActionBy))
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => src.ActionBy));
            CreateMap<BankUpdateRequestModel, BankEntity>()
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => src.ActionBy));
            
            CreateMap<LookUpEntity, CommonNestedResponseModel>();
        }
    }
}
