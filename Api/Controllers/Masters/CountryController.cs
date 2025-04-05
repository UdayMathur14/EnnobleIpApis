using BusinessLogic.Interfaces.Masters;
using DataAccess.Domain.Masters.Country;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.Country;
using Models.ResponseModels.Masters.Country;
using Utilities;

namespace Api.Controllers.V1.Masters
{
    [Route("api/country/")]
    [ApiController]
    public class CountryController(ICountryService countryService) : CssControllerBase
    {
       
        [ProducesResponseType(typeof(MessageStatusModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CountryReadResponseModel), StatusCodes.Status200OK)]
        [HttpGet("{countryId}")]
        public async Task<ActionResult> Get(int countryId)
        {
            IResponseWrapper<CountryReadResponseModel> result = await countryService.GetCountryAsync(countryId);
            return HandleResponse(result);
        }

        
        [HttpPost("search")]
        public async Task<ActionResult> Search(CountrySearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<CountrySearchResponse> result = await countryService.SearchCountryAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

        [HttpPut("update/{countryId}")]
        public async Task<IActionResult> Update(int countryId,CountryRequestModel country)
        {
            IResponseWrapper<CountryReadResponseModel> result = await countryService.UpdateCountryAsync(country, countryId);
            return HandleResponse(result);
        }        
    }
}
