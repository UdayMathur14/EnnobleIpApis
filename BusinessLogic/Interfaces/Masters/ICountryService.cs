using DataAccess.Domain.Masters.Country;
using Models.RequestModels.Masters.Country;
using Models.ResponseModels.Masters.Country;
using Utilities;

namespace BusinessLogic.Interfaces.Masters
{
    
    public interface ICountryService
    {
        Task<IResponseWrapper<CountryReadResponseModel>> GetCountryAsync(int countryId);
        Task<IResponseWrapper<CountrySearchResponse>> SearchCountryAsync(CountrySearchRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<CountryReadResponseModel>> UpdateCountryAsync(CountryRequestModel requestModel, int countryId);
    }
}
