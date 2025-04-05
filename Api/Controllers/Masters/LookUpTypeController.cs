using BusinessLogic.Interfaces.Masters;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.LookUpType;
using Models.ResponseModels.Masters.LookUpType;
using Utilities;

namespace Api.Controllers.V1.Masters
{
    [Route("api/lookup-type/")]
    [ApiController]
    public class LookUpTypeController(ILookUpTypeService lookUpTypeService) : CssControllerBase
    {
        [ProducesResponseType(typeof(MessageStatusModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(LookUpTypeReadResponseModel), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            IResponseWrapper<LookUpTypeReadResponseModel> result = await lookUpTypeService.GetLookUpAsync(id);
            return HandleResponse(result);
        }

        [HttpPost("search")]
        public async Task<ActionResult> Search(LookUpTypeSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<LookUpTypeSearchResponse> result = await lookUpTypeService.SearchLookUpAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, LookupTypeUpdateRequestModel lookUp)
        {
            IResponseWrapper<LookUpTypeReadResponseModel> result = await lookUpTypeService.UpdateLookUpAsync(lookUp, id);
            return HandleResponse(result);
        }

   
        [HttpPost("create")]
        public async Task<IActionResult> Create(LookUpTypeRequestModel lookUp)
        {
            IResponseWrapper<LookUpTypeCreateResponseModel> result = await lookUpTypeService.CreateLookUpAsync(lookUp);
            return HandleResponse(result, StatusCodes.Status201Created);
        }
    }
}
