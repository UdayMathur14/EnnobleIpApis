using AutoMapper;
using BusinessLogic.Interfaces.Masters;
using DataAccess.Domain.Masters.LookUpType;
using DataAccess.Interfaces.Masters;
using Models.RequestModels.Masters.LookUpType;
using Models.ResponseModels.Masters.LookUpType;
using Utilities;
using Utilities.Constants;
using Utilities.Extensions;
using Utilities.Implementation;

namespace BusinessLogic.Services.Masters
{
    internal class LookUpTypeService(ILookUpTypeRepository lookUpTypeRepository, IMapper mapper) : ILookUpTypeService
    {
        public async Task<IResponseWrapper<LookUpTypeReadResponseModel>> GetLookUpAsync(int id)
        {
            var wrapper = new ResponseWrapper<LookUpTypeReadResponseModel>();
            LookUpTypeEntity? lookUpTypeEntity = await lookUpTypeRepository.FindAsync(id);

            if (lookUpTypeEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }

            LookUpTypeReadResponseModel response = mapper.Map<LookUpTypeReadResponseModel>(lookUpTypeEntity);
            wrapper.Response = response;

            return wrapper;
        }

    
        public async Task<IResponseWrapper<LookUpTypeSearchResponse>> SearchLookUpAsync(LookUpTypeSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<LookUpTypeSearchResponse>();

            LookUpTypeSearchRequestEntity? request = mapper.Map<LookUpTypeSearchRequestEntity>(requestModel);

            LookUpTypeSearchResponseEntity entityResponse = await lookUpTypeRepository.SearchLookUpAsync(request);
            LookUpTypeSearchResponse lookUpReadResponse = mapper.Map<LookUpTypeSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }

     
        public async Task<IResponseWrapper<LookUpTypeReadResponseModel>> UpdateLookUpAsync(LookupTypeUpdateRequestModel requestModel, int id)
        {
            var wrapper = new ResponseWrapper<LookUpTypeReadResponseModel>();

            LookUpTypeEntity? lookUpTypeEntity = await lookUpTypeRepository.FindAsync(id);

            if (lookUpTypeEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }
            else
            {
                mapper.Map(requestModel, lookUpTypeEntity);
                if (requestModel.Status == Status.Inactive.ToString() && lookUpTypeEntity.Status != Status.Active.ToString())
                {
                    lookUpTypeEntity.InactiveDate = DateTime.Now;
                }
                var lookUpTypeResponse = await lookUpTypeRepository.UpdateAsync(lookUpTypeEntity);

                LookUpTypeReadResponseModel lookUpTypeSearchResponse = mapper.Map<LookUpTypeReadResponseModel>(lookUpTypeResponse);
                wrapper.Response = lookUpTypeSearchResponse;
            }
            return wrapper;
        }

       
        public async Task<IResponseWrapper<LookUpTypeCreateResponseModel>> CreateLookUpAsync(LookUpTypeRequestModel requestModel)
        {
            var wrapper = new ResponseWrapper<LookUpTypeCreateResponseModel>();

            LookUpTypeEntity? lookUpTypeEntity = await lookUpTypeRepository.IsExistsAsync(requestModel.Type);

            if (lookUpTypeEntity != null)
            {
                wrapper.Messages.Add(Messages.AlreadyExists.ToDetailModel(requestModel.Type.ToString()));
            }
            else
            {
                LookUpTypeEntity entity = mapper.Map<LookUpTypeEntity>(requestModel);

                entity.LastUpdatedBy = entity.CreatedBy = requestModel.ActionBy;
                entity.Status = Status.Active.ToString();

                int id = await lookUpTypeRepository.AddAsync(entity);

                wrapper.Response = new LookUpTypeCreateResponseModel()
                {
                    Id = id
                };
            }
            return wrapper;
        }
    }
}
