using AutoMapper;
using BusinessLogic.Interfaces.VendorInvoiceReports;
using DataAccess.Interfaces.VendorInvoiceReport;
using Models.ResponseModels.Masters.VendorInvoiceReport;
using Utilities;
using Utilities.Implementation;

namespace BusinessLogic.Services.VendorInvoiceReports
{
    internal class VendorInvoiceReportService(IVendorInvoiceReportRepository VendorInvoiceReportRepository, IMapper mapper) : IVendorInvoiceReportService
    {

        public async Task<IResponseWrapper<VendorInvoiceReportSearchResponse>> SearchVendorInvoiceReportAsync(VendorInvoiceReportSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceReportSearchResponse>();

            VendorInvoiceReportSearchRequestEntity? request = mapper.Map<VendorInvoiceReportSearchRequestEntity>(requestModel);

            VendorInvoiceReportSearchResponseEntity entityResponse = await VendorInvoiceReportRepository.SearchVendorInvoiceReportAsync(request);
            VendorInvoiceReportSearchResponse lookUpReadResponse = mapper.Map<VendorInvoiceReportSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }







    }
}
