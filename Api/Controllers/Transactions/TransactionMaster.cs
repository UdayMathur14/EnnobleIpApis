using BusinessLogic.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.Transaction;
using Models.ResponseModels.Masters.Transaction;
using Models.ResponseModels.Transactions.Transaction;
using Utilities;

namespace Api.Controllers.Transactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(ITransactionService transactionService) : CssControllerBase
    {
        [ProducesResponseType(typeof(MessageStatusModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(TransactionReadResponseModel), StatusCodes.Status200OK)]

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            IResponseWrapper<TransactionReadResponseModel> result = await transactionService.GetTransactionAsync(id);
            return HandleResponse(result);
        }

        [HttpPost("search")]
        public async Task<ActionResult> Search(TransactionSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<TransactionSearchResponse> result = await transactionService.SearchTransactionAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, TransactionUpdateRequestModel Transaction)
        {
            IResponseWrapper<TransactionReadResponseModel> result = await transactionService.UpdateTransactionAsync(Transaction, id);
            return HandleResponse(result);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(TransactionRequestModel Transaction)
        {
            IResponseWrapper<TransactionCreateResponseModel> result = await transactionService.CreateTransactionAsync(Transaction);
            return HandleResponse(result, StatusCodes.Status201Created);
        }
    }
}
