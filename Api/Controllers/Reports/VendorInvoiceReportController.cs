using BusinessLogic.Interfaces.Masters;
using BusinessLogic.Interfaces.VendorInvoiceReports;
using BusinessLogic.Interfaces.VendorInvoiceTxns;
using Microsoft.AspNetCore.Mvc;
using Models.RequestModels.Masters.Vendor;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.RequestModels.Reports.VendorInvoiceReport;
using Models.ResponseModels.Masters.Vendor;
using Models.ResponseModels.Masters.VendorInvoiceReport;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Reports.VendorInvoiceReport;
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
        [HttpPost("outstandingVendorPaymentSingle")]
        public async Task<ActionResult> Search1(VendorInvoiceTxnSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorInvoiceTxnSearchResponse> result = await vendorInvoiceReportService.SearchVendorInvoiceTxnAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

        [HttpPost("outstandingVendorPaymentgroup")]
        public async Task<ActionResult> Search3(VendorInvoiceTxnSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorPurchaseReportSearchResponse> result = await vendorInvoiceReportService.SearchVendorInvoiceTxnAsync3(requestModel, offset, count!);
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

        [HttpPost("searchvendor")]
        public async Task<ActionResult> Search(VendorSearchRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorSearchResponse> result = await vendorInvoiceReportService.SearchVendorAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }


        [HttpPost("vendorpurchase")]
        public async Task<ActionResult> Search2(VendorPurchaseRequestModel requestModel, [FromQuery] string? offset = null, [FromQuery] string? count = null)
        {
            IResponseWrapper<VendorPurchaseReportSearchResponse> result = await vendorInvoiceReportService.SearchVendorPurchaseAsync(requestModel, offset, count!);
            return HandleResponse(result);
        }

    }
}
