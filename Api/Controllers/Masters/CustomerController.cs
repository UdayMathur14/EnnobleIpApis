using BusinessLogic.Interfaces.Masters;
using DataAccess.Domain.Masters.Customer;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.Customer;
using Models.ResponseModels.Masters.Customer;
using Utilities;

namespace Api.Controllers.V1.Masters
{
    [Route("api/customer/")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : CssControllerBase
    {
        [ProducesResponseType(typeof(MessageStatusModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomerReadResponseModel), StatusCodes.Status200OK)]
        [HttpGet("{customerId}")]
        public async Task<ActionResult> Get(int customerId)
        {
            IResponseWrapper<CustomerReadResponseModel> result = await customerService.GetCustomerAsync(customerId);
            return HandleResponse(result);
        }

      
        [HttpPost("search")]
        public async Task<ActionResult> Search(CustomerSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<CustomerSearchResponse> result = await customerService.SearchCustomerAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

        
        [HttpPut("update/{customerId}")]
        public async Task<IActionResult> Update(int customerId, CustomerRequestModel customer)
        {
            IResponseWrapper<CustomerReadResponseModel> result = await customerService.UpdateCustomerAsync(customer, customerId);
            return HandleResponse(result);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(CustomerRequestModel Customer)
        {
            IResponseWrapper<CustomerCreateResponseModel> result = await customerService.CreateCustomerAsync(Customer);
            return HandleResponse(result, StatusCodes.Status201Created);
        }
    }
}
