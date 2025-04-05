using Models.ResponseModels.BaseResponseSetup;
using Models.ResponseModels.Masters.Country;

namespace Models.ResponseModels.Masters.Country
{
    public class CountrySearchResponse : SearchResponseBase<CountryReadResponseModel>
    {
        public List<CountryReadResponseModel> Countrys => base.Results;
    }
}
