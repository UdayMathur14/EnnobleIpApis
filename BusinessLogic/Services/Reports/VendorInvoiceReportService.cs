using AutoMapper;
using BusinessLogic.Interfaces.VendorInvoiceReports;
using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Reports.VendorInvoiceReport;
using DataAccess.Interfaces.VendorInvoiceReport;
using Models.RequestModels.Masters.Vendor;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.RequestModels.Reports.VendorInvoiceReport;
using Models.ResponseModels.Masters.Vendor;
using Models.ResponseModels.Masters.VendorInvoiceReport;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Reports.VendorInvoiceReport;
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

        public async Task<IResponseWrapper<VendorPurchaseReportSearchResponse>> SearchVendorInvoiceTxnAsync3(VendorInvoiceTxnSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorPurchaseReportSearchResponse>();

            VendorInvoiceTxnSearchRequestEntity? request = mapper.Map<VendorInvoiceTxnSearchRequestEntity>(requestModel);

            PurchaseVendorHistoryResponseEntity entityResponse = await VendorInvoiceReportRepository.SearchVendorInvoiceTxnAsync3(request);
            VendorPurchaseReportSearchResponse lookUpReadResponse = mapper.Map<VendorPurchaseReportSearchResponse>(entityResponse);

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

        public async Task<IResponseWrapper<VendorPurchaseReportSearchResponse>> SearchVendorPurchaseAsync(VendorPurchaseRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorPurchaseReportSearchResponse>();

            VendorInvoiceReportSearchRequestEntity? request = mapper.Map<VendorInvoiceReportSearchRequestEntity>(requestModel);

            PurchaseVendorHistoryResponseEntity entityResponse = await VendorInvoiceReportRepository.SearchVendorPurchaseAsync(request);
            VendorPurchaseReportSearchResponse lookUpReadResponse = mapper.Map<VendorPurchaseReportSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }

        public Task<IResponseWrapper<VendorInvoiceTxnSearchResponse>> SearchVendorInvoiceTxnAsync(VendorInvoiceTxnSearchRequestModel requestModel, string? offset, string count)
        {
            throw new NotImplementedException();
        }
    }
}
