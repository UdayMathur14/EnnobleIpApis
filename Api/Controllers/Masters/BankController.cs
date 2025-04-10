using BusinessLogic.Interfaces.Masters;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.Bank;
using Models.ResponseModels.Masters.Bank;
using Utilities;

namespace Api.Controllers.V1.Masters
{
    [Route("api/bank/")]
    [ApiController]
    public class BankController(IBankService bankService) : CssControllerBase
    {
        [ProducesResponseType(typeof(MessageStatusModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BankReadResponseModel), StatusCodes.Status200OK)]
        [HttpGet("{bankId}")]
        public async Task<ActionResult> Get(int bankId)
        {
            IResponseWrapper<BankReadResponseModel> result = await bankService.GetBankAsync(bankId);
            return HandleResponse(result);
        }

        [HttpPost("search")]
        public async Task<ActionResult> Search(BankSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<BankSearchResponseModel> result = await bankService.SearchBankAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

      
        [HttpPut("update/{bankId}")]
        public async Task<IActionResult> Update(int bankId,BankUpdateRequestModel bank)
        {
            IResponseWrapper<BankReadResponseModel> result = await bankService.UpdateBankAsync(bank, bankId);
            return HandleResponse(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(BankRequestModel bank)
        {
            IResponseWrapper<BankCreateResponseModel> result = await bankService.CreateBankAsync(bank);
            return HandleResponse(result, StatusCodes.Status201Created);
        }

    }
}
