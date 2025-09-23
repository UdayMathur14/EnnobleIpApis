using BusinessLogic.Interfaces.VendorInvoiceTxns;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.RequestModels.Transactions.VendorInvoiceTxn;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Transaction.VendorInvoiceTxn;
using Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn;
using Utilities;

namespace Api.Controllers.VendorInvoiceTxn
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorInvoiceTxnController(IVendorInvoiceTxnService vendorInvoiceTxnService) : CssControllerBase
    {
        [ProducesResponseType(typeof(MessageStatusModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(VendorInvoiceTxnReadResponseModel), StatusCodes.Status200OK)]

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            IResponseWrapper<VendorInvoiceTxnReadResponseModel> result = await vendorInvoiceTxnService.GetVendorInvoiceTxnAsync(id);
            return HandleResponse(result);
        }

        [HttpPost("search")]
        public async Task<ActionResult> Search(VendorInvoiceTxnSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorInvoiceTxnSearchResponse> result = await vendorInvoiceTxnService.SearchVendorInvoiceTxnAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, VendorInvoiceTxnUpdateRequestModel VendorInvoiceTxn)
        {
            IResponseWrapper<VendorInvoiceTxnReadResponseModel> result = await vendorInvoiceTxnService.UpdateVendorInvoiceTxnAsync(VendorInvoiceTxn, id);
            return HandleResponse(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(VendorInvoiceTxnRequestModel VendorInvoiceTxn)
        {
            IResponseWrapper<VendorInvoiceTxnCreateResponseModel> result = await vendorInvoiceTxnService.CreateVendorInvoiceTxnAsync(VendorInvoiceTxn);
            return HandleResponse(result, StatusCodes.Status201Created);
        }

        [HttpPost("paymentDetails")]
        public async Task<IActionResult> AddPayemnt(VendorInvoicePaymentRequest VendorInvoiceTxn)
        {
            IResponseWrapper<VendorInvoiceTxnCreateResponseModel> result = await vendorInvoiceTxnService.AddPaymentDetailsTxnAsync(VendorInvoiceTxn);
            return HandleResponse(result, StatusCodes.Status201Created);
        }

        //[HttpPost("searchPendingInvoices")]
        //public async Task<ActionResult> SearchPendingPayments(VendorInvoicePaymentSearchRequest requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        //{
        //    IResponseWrapper<VendorPaymentSearchResponse> result = await vendorInvoiceTxnService.SearchPaymentInvoiceTxnAsync(requestModel, offset, count!);
        //    return HandleResponse(result);
        //}


    }

}
