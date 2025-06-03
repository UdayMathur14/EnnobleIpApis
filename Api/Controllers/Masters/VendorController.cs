using BusinessLogic.Interfaces.Masters;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.Vendor;
using Models.ResponseModels.Masters.Vendor;
using Utilities;

namespace Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController(IVendorService vendorService) : CssControllerBase
    {
        [ProducesResponseType(typeof(MessageStatusModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(VendorReadResponseModel), StatusCodes.Status200OK)]

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            IResponseWrapper<VendorReadResponseModel> result = await vendorService.GetVendorAsync(id);
            return HandleResponse(result);
        }

        [HttpPost("search")]
        public async Task<ActionResult> Search(VendorSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorSearchResponse> result = await vendorService.SearchVendorAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, VendorUpdateRequestModel Vendor)
        {
            IResponseWrapper<VendorReadResponseModel> result = await vendorService.UpdateVendorAsync(Vendor, id);
            return HandleResponse(result);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(VendorRequestModel Vendor)
        {
            IResponseWrapper<VendorCreateResponseModel> result = await vendorService.CreateVendorAsync(Vendor);
            return HandleResponse(result, StatusCodes.Status201Created);
        }
    }
}
