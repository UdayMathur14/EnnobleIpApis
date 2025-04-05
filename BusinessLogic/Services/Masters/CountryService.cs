using AutoMapper;
using BusinessLogic.Interfaces.Masters;
using BusinessLogic.Rules.Enums;
using BusinessLogic.Rules.Master.Country;
using DataAccess.Domain.Masters.Country;
using DataAccess.Interfaces.Masters;
using Models.RequestModels.Masters.Country;
using Models.ResponseModels.Masters.Country;
using Utilities;
using Utilities.Constants;
using Utilities.Extensions;
using Utilities.Implementation;

namespace BusinessLogic.Services.Masters
{
    internal class CountryService(ICountryRepository countryRepository, IMapper mapper) : ICountryService
    {
        public async Task<IResponseWrapper<CountryReadResponseModel>> GetCountryAsync(int countryId)
        {
            var wrapper = new ResponseWrapper<CountryReadResponseModel>();

            CountryEntity? countryEntity = await countryRepository.FindAsync(countryId);

            if (countryEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel($"CountryId: {countryId}"));
                return wrapper;
            }

            CountryReadResponseModel response = mapper.Map<CountryReadResponseModel>(countryEntity);
            wrapper.Response = response;

            return wrapper;
        }

  
        public async Task<IResponseWrapper<CountrySearchResponse>> SearchCountryAsync(CountrySearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<CountrySearchResponse>();

                CountrySearchRequestEntity? request = mapper.Map<CountrySearchRequestEntity>(requestModel);
                var rules = new CountrySearchRules(request, offset, count);
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

                CountrySearchResponseEntity entityResponse = await countryRepository.SearchCountryAsync(request);
                CountrySearchResponse countryReadResponse = mapper.Map<CountrySearchResponse>(entityResponse);

                wrapper.Response = countryReadResponse;

                return wrapper;
        }


        public async Task<IResponseWrapper<CountryReadResponseModel>> UpdateCountryAsync(CountryRequestModel requestModel, int countryId)
        {
            var wrapper = new ResponseWrapper<CountryReadResponseModel>();

            CountryEntity? countryEntity = await countryRepository.FindAsync(countryId);

            if (countryEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel($"CountryId: {countryId}"));
                return wrapper;
            }
            else
            {
                mapper.Map(requestModel, countryEntity);

                if (requestModel.Status == Status.Inactive.ToString() && countryEntity.Status != Status.Active.ToString())
                {
                    countryEntity.InactiveDate = DateTime.Now;
                }

                var updatedEntity = await countryRepository.UpdateAsync(countryEntity);

                CountryReadResponseModel responseModel = mapper.Map<CountryReadResponseModel>(updatedEntity);
                wrapper.Response = responseModel;
            }

            return wrapper;
        }
    }
}
