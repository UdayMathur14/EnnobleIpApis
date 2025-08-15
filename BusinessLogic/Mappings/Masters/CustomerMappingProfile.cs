using AutoMapper;
using DataAccess.Domain;
using DataAccess.Domain.Masters.Customer;
using Models.RequestModels.Masters.Customer;
using Models.ResponseModels;
using Models.ResponseModels.Masters.Customer;

namespace BusinessLogic.Mappings.Masters
{
    public class CustomerMappingProfile : Profile
    {
        /// <summary>
        /// <purpose>Customer mapping profile</purpose>
        /// <createdBy>Milan Jindal</createdBy>
        /// <createdOn>17-Aprl-2024</createdOn>
        /// <modifiedBy>Milan Jindal</modifiedBy>
        /// <modifiedOn>17-Aprl-2024</modifiedOn>
        /// </summary>
        public CustomerMappingProfile()
        {
            CreateMap<CustomerSearchRequestModel, CustomerSearchRequestEntity>();
            CreateMap<CustomerEntity, CustomerReadResponseModel>();
            CreateMap<CustomerSearchResponseEntity, CustomerSearchResponse>();
            CreateMap<CustomerRequestModel, CustomerRequestEntity>();
            CreateMap<CustomerEntity, CustomerSearchResponse>();
            CreateMap<CustomerRequestModel, CustomerEntity>();  
        }
    }
}
