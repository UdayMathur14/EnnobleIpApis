using BusinessLogic.Interfaces.VendorInvoiceReports;
using BusinessLogic.Interfaces.VendorInvoiceTxns;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Masters.VendorInvoiceReport;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using Utilities;

namespace Api.Controllers.Reports
{
    [Route("api/report")]
    [ApiController]
    public class VendorInvoiceReportController(IVendorInvoiceReportService vendorInvoiceReportService) : CssControllerBase
    {
        [HttpPost("search")]
        public async Task<ActionResult> Search(VendorInvoiceReportRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorInvoiceReportSearchResponse> result = await vendorInvoiceReportService.SearchVendorInvoiceReportAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

        //outstanding Amount or not 
        [HttpPost("search1")]
        public async Task<ActionResult> Search1(VendorInvoiceTxnSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorInvoiceTxnSearchResponse> result = await vendorInvoiceReportService.SearchVendorInvoiceTxnAsync1(requestModel, offset, count!);
            return HandleResponse(result);
        }

        [HttpPost("saleinvoicecreated")]
        public async Task<ActionResult> SaleInvoiceCreated(VendorInvoiceReportRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorInvoiceReportSearchResponse> result = await vendorInvoiceReportService.SearchSaleInvoiceReportAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

        [HttpPost("customerinvoicetotal")]
        public async Task<ActionResult> CustomerInvoiceTotal(VendorInvoiceReportRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorInvoiceReportSearchResponse> result = await vendorInvoiceReportService.SearchCustomerInvoiceTotalReportAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

    }
}
