using BusinessLogic.Interfaces.VendorInvoiceReports;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Masters.VendorInvoiceReport;
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
    }
}
