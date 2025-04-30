using AutoMapper;
using DataAccess.Domain.Masters.State;
using DataAccess.Domain.Masters.LookUp;
using Models.RequestModels.Masters.State;
using Models.ResponseModels.Masters.State;
using Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappings.Masters
{
    public class StateMappingProfile : Profile
    {

        public StateMappingProfile()
        {
            CreateMap<StateSearchRequestModel, StateSearchRequestEntity>();
            CreateMap<StateEntity, StateReadResponseModel>();

            CreateMap<StateSearchResponseEntity, StateSearchResponse>();
            CreateMap<StateEntity, StateSearchResponse>();
            CreateMap<LookUpEntity, CommonNestedResponseModel>();

        }
    }
}
