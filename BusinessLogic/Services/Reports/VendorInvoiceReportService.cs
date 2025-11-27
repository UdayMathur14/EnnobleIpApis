using AutoMapper;
using BusinessLogic.Interfaces.VendorInvoiceReports;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Interfaces.VendorInvoiceReport;
using DataAccess.Interfaces.VendorInvoiceTxn;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Masters.VendorInvoiceReport;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using Utilities;
using Utilities.Implementation;

namespace BusinessLogic.Services.VendorInvoiceReports
{
    internal class VendorInvoiceReportService(IVendorInvoiceReportRepository VendorInvoiceReportRepository, IMapper mapper) : IVendorInvoiceReportService
    {
        public async Task<IResponseWrapper<VendorInvoiceReportSearchResponse>> SearchVendorInvoiceReportAsync(VendorInvoiceReportRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceReportSearchResponse>();

            VendorInvoiceReportSearchRequestEntity? request = mapper.Map<VendorInvoiceReportSearchRequestEntity>(requestModel);

            VendorInvoiceReportSearchResponseEntity entityResponse = await VendorInvoiceReportRepository.SearchVendorInvoiceReportAsync(request);
            VendorInvoiceReportSearchResponse lookUpReadResponse = mapper.Map<VendorInvoiceReportSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }

        public async Task<IResponseWrapper<VendorInvoiceTxnSearchResponse>> SearchVendorInvoiceTxnAsync1(VendorInvoiceTxnSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceTxnSearchResponse>();

            VendorInvoiceTxnSearchRequestEntity? request = mapper.Map<VendorInvoiceTxnSearchRequestEntity>(requestModel);

            VendorInvoiceTxnSearchResponseEntity entityResponse = await VendorInvoiceReportRepository.SearchVendorInvoiceTxnAsync1(request);
            VendorInvoiceTxnSearchResponse lookUpReadResponse = mapper.Map<VendorInvoiceTxnSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }

        public async Task<IResponseWrapper<VendorInvoiceReportSearchResponse>> SearchSaleInvoiceReportAsync(VendorInvoiceReportRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceReportSearchResponse>();

            VendorInvoiceReportSearchRequestEntity? request = mapper.Map<VendorInvoiceReportSearchRequestEntity>(requestModel);

            VendorInvoiceReportSearchResponseEntity entityResponse = await VendorInvoiceReportRepository.SearchSaleInvoiceReportAsync(request);
            VendorInvoiceReportSearchResponse lookUpReadResponse = mapper.Map<VendorInvoiceReportSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }


        public async Task<IResponseWrapper<VendorInvoiceReportSearchResponse>> SearchCustomerInvoiceTotalReportAsync(VendorInvoiceReportRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceReportSearchResponse>();

            VendorInvoiceReportSearchRequestEntity? request = mapper.Map<VendorInvoiceReportSearchRequestEntity>(requestModel);

            VendorInvoiceReportSearchResponseEntity entityResponse = await VendorInvoiceReportRepository.SearchCustomerInvoiceTotalReportAsync(request);
            VendorInvoiceReportSearchResponse lookUpReadResponse = mapper.Map<VendorInvoiceReportSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }


    }
}
