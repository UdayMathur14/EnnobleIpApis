using BusinessLogic.Interfaces.Masters;
using DataAccess.Domain.Masters;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters;
using Models.ResponseModels.Masters;
using Models.ResponseModels.Masters.LookUp;
using Utilities;

namespace Api.Controllers.V1.Masters
{
    [Route("api/lookup/")]
    [ApiController]
    public class LookUpController(ILookUpService lookUpService) : CssControllerBase
    {
        
        [ProducesResponseType(typeof(MessageStatusModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(LookUpReadResponseModel), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            IResponseWrapper<LookUpReadResponseModel> result = await lookUpService.GetLookUpAsync(id);
            return HandleResponse(result);
        }

       
        [HttpPost("search")]
        public async Task<ActionResult> Search(LookUpSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<LookUpSearchResponse> result = await lookUpService.SearchLookUpAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

       
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, LookupUpdateRequestModel lookUp)
        {
            IResponseWrapper<LookUpReadResponseModel> result = await lookUpService.UpdateLookUpAsync(lookUp, id);
            return HandleResponse(result);
        }

        
        [HttpPost("create")]
        public async Task<IActionResult> Create(LookUpRequestModel lookUp)
        {
            IResponseWrapper<LookUpCreateResponseModel> result = await lookUpService.CreateLookUpAsync(lookUp);
            return HandleResponse(result, StatusCodes.Status201Created);
        }

        
        [HttpGet("type/{type}")]
        public async Task<ActionResult> SearchType(string type)
        {
            IResponseWrapper<LookUpSearchResponse> result = await lookUpService.SearchLookUpByTypeAsync(type);
            return HandleResponse(result);
        }
    }
}
