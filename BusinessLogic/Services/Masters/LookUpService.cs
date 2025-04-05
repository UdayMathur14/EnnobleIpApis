using AutoMapper;
using BusinessLogic.Interfaces.Masters;
using BusinessLogic.Rules.Enums;
using BusinessLogic.Rules.Master.LookUp;
using DataAccess.Domain.Masters;
using DataAccess.Domain.Masters.LookUp;
using DataAccess.Interfaces.Masters;
using Models.RequestModels.Masters;
using Models.ResponseModels.Masters;
using Models.ResponseModels.Masters.LookUp;
using Utilities;
using Utilities.Constants;
using Utilities.Extensions;
using Utilities.Implementation;

namespace BusinessLogic.Services.Masters
{
    internal class LookUpService(ILookUpRepository lookUpRepository, IMapper mapper) : ILookUpService
    {
        public async Task<IResponseWrapper<LookUpReadResponseModel>> GetLookUpAsync(int id)
        {
            var wrapper = new ResponseWrapper<LookUpReadResponseModel>();
            LookUpEntity? lookUpEntity = await lookUpRepository.FindAsync(id);

            if (lookUpEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }

            LookUpReadResponseModel response = mapper.Map<LookUpReadResponseModel>(lookUpEntity);
            wrapper.Response = response;

            return wrapper;
        }

        public async Task<IResponseWrapper<LookUpSearchResponse>> SearchLookUpAsync(LookUpSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<LookUpSearchResponse>();

            LookUpSearchRequestEntity? request = mapper.Map<LookUpSearchRequestEntity>(requestModel);
            var rules = new LookUpSearchRules(request, offset, count);
            rules.RunRules();
            foreach (var result in rules.Results)
            {
                if (result.ResultCode == RuleResultType.Fail && result.Exception != null)
                {
                    wrapper.Messages.Add(Messages.GetErrorDetail(
                        result.Exception.Code,
                        result.Exception.Message,
                        result.Exception.Element,
                        result.Exception.Category)
                        .ToDetailModel(result.Exception.ElementValue));
                }
            }
            if (rules.Result == RuleResultType.Fail)
            {
                return wrapper;
            }
            LookUpSearchResponseEntity entityResponse = await lookUpRepository.SearchLookUpAsync(request);
            LookUpSearchResponse lookUpReadResponse = mapper.Map<LookUpSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }

        
        public async Task<IResponseWrapper<LookUpReadResponseModel>> UpdateLookUpAsync(LookupUpdateRequestModel requestModel, int id)
        {
            var wrapper = new ResponseWrapper<LookUpReadResponseModel>();

            LookUpEntity? lookUpEntity = await lookUpRepository.FindAsync(id);

            if (lookUpEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }
            else
            {
                mapper.Map(requestModel, lookUpEntity);
                if (requestModel.Status == Status.Inactive.ToString() && lookUpEntity.Status != Status.Active.ToString())
                {
                    lookUpEntity.InactiveDate = DateTime.Now;
                }
                var lookUpResponse = await lookUpRepository.UpdateAsync(lookUpEntity);

                LookUpReadResponseModel lookUpSearchResponse = mapper.Map<LookUpReadResponseModel>(lookUpResponse);
                wrapper.Response = lookUpSearchResponse;
            }
            return wrapper;
        }

        
        public async Task<IResponseWrapper<LookUpCreateResponseModel>> CreateLookUpAsync(LookUpRequestModel requestModel)
        {
            var wrapper = new ResponseWrapper<LookUpCreateResponseModel>();

            LookUpEntity? lookUpEntity = await lookUpRepository.IsExistsAsync(requestModel.Code, requestModel.Value, requestModel.TypeId);

            if (lookUpEntity != null)
            {
                wrapper.Messages.Add(Messages.AlreadyExists.ToDetailModel(requestModel.Value.ToString()));
            }
            else
            {
                LookUpEntity entity = mapper.Map<LookUpEntity>(requestModel);

                entity.LastUpdatedBy = entity.CreatedBy = requestModel.ActionBy;
                entity.Status = Status.Active.ToString();

                int id = await lookUpRepository.AddAsync(entity);

                wrapper.Response = new LookUpCreateResponseModel()
                {
                    Id = id
                };
            }
            return wrapper;
        }


        public async Task<IResponseWrapper<LookUpSearchResponse>> SearchLookUpByTypeAsync(string type)
        {
            var wrapper = new ResponseWrapper<LookUpSearchResponse>();
            List<LookUpEntity> lookupEntities = await lookUpRepository.SearchByTypeAsync(type);

            if (lookupEntities.Count == 0)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(type.ToString()));
            }
            else
            {
                List<LookUpReadResponseModel> lookupResponseModels = mapper.Map<List<LookUpReadResponseModel>>(lookupEntities);
                var response = new LookUpSearchResponse { LookUps = lookupResponseModels };
                wrapper.Response = response;
            }

            return wrapper;
        }
    }
}
