using AutoMapper;
using BusinessLogic.Interfaces.Masters;
using BusinessLogic.Rules.Enums;
using BusinessLogic.Rules.Master.State;
using DataAccess.Domain.Masters.State;
using DataAccess.Interfaces.Masters;
using Models.RequestModels.Masters.State;
using Models.ResponseModels.Masters.State;
using Utilities;
using Utilities.Constants;
using Utilities.Extensions;
using Utilities.Implementation;

namespace BusinessLogic.Services.Masters
{
    internal class StateService(IStateRepository stateRepository, IMapper mapper) : IStateService
    {
        public async Task<IResponseWrapper<StateSearchResponse>> SearchStateAsync(StateSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<StateSearchResponse>();

            StateSearchRequestEntity? request = mapper.Map<StateSearchRequestEntity>(requestModel);
            var rules = new StateSearchRules(request, offset, count);
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

            StateSearchResponseEntity entityResponse = await stateRepository.SearchStateAsync(request);
            StateSearchResponse stateReadResponse = mapper.Map<StateSearchResponse>(entityResponse);

            wrapper.Response = stateReadResponse;

            return wrapper;
        }


        
    }
}
