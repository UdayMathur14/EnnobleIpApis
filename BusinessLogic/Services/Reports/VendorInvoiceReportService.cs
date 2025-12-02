using AutoMapper;
using BusinessLogic.Interfaces.VendorInvoiceReports;
using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Interfaces.Masters;
using DataAccess.Interfaces.VendorInvoiceReport;
using DataAccess.Interfaces.VendorInvoiceTxn;
using Models.RequestModels.Masters.Vendor;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.RequestModels.Reports.VendorInvoiceReport;
using Models.ResponseModels.Masters.Vendor;
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

        public async Task<IResponseWrapper<VendorSearchResponse>> SearchVendorAsync(VendorSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorSearchResponse>();

            VendorSearchRequestEntity? request = mapper.Map<VendorSearchRequestEntity>(requestModel);

            VendorSearchResponseEntity entityResponse = await VendorInvoiceReportRepository.SearchVendorAsync(request);
            VendorSearchResponse lookUpReadResponse = mapper.Map<VendorSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }

        public async Task<IResponseWrapper<VendorInvoiceReportSearchResponse>> SearchVendorPurchaseAsync(VendorPurchaseRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceReportSearchResponse>();

            VendorInvoiceReportSearchRequestEntity? request = mapper.Map<VendorInvoiceReportSearchRequestEntity>(requestModel);

            VendorInvoiceReportSearchResponseEntity entityResponse = await VendorInvoiceReportRepository.SearchVendorPurchaseAsync(request);
            VendorInvoiceReportSearchResponse lookUpReadResponse = mapper.Map<VendorInvoiceReportSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }
        
    }
}
