using BusinessLogic.Interfaces.Masters;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.State;
using Models.ResponseModels.Masters.State;
using Utilities;

namespace Api.Controllers.Masters
{
    [Route("api/state/")]
    [ApiController]
    public class StateController(IStateService stateService) : CssControllerBase
    {
        [HttpPost("search")]
        public async Task<ActionResult> Search(StateSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<StateSearchResponse> result = await stateService.SearchStateAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }
    }
}
