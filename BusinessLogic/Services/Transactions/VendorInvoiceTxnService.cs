using AutoMapper;
using Azure.Core;
using BusinessLogic.Interfaces.VendorInvoiceTxns;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Transactions.VendorInvoiceTxn;
using DataAccess.Interfaces.VendorInvoiceTxn;
using Models.RequestModels.Masters.VendorInvoiceTxn;
using Models.RequestModels.Transactions.VendorInvoiceTxn;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using Models.ResponseModels.Transaction.VendorInvoiceTxn;
using Models.ResponseModels.VendorInvoiceTxn.VendorInvoiceTxn;
using Utilities;
using Utilities.Constants;
using Utilities.Extensions;
using Utilities.Implementation;

namespace BusinessLogic.Services.VendorInvoiceTxns
{
    internal class VendorInvoiceTxnService(IVendorInvoiceTxnRepository VendorInvoiceTxnRepository, IMapper mapper) : IVendorInvoiceTxnService
    {
        public async Task<IResponseWrapper<VendorInvoiceTxnReadResponseModel>> GetVendorInvoiceTxnAsync(int id)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceTxnReadResponseModel>();
            VendorInvoiceTxnEntity? VendorInvoiceTxnEntity = await VendorInvoiceTxnRepository.FindAsync(id);

            if (VendorInvoiceTxnEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }

            VendorInvoiceTxnReadResponseModel response = mapper.Map<VendorInvoiceTxnReadResponseModel>(VendorInvoiceTxnEntity);
            wrapper.Response = response;

            return wrapper;
        }


        public async Task<IResponseWrapper<VendorInvoiceTxnSearchResponse>> SearchVendorInvoiceTxnAsync(VendorInvoiceTxnSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceTxnSearchResponse>();

            VendorInvoiceTxnSearchRequestEntity? request = mapper.Map<VendorInvoiceTxnSearchRequestEntity>(requestModel);

            VendorInvoiceTxnSearchResponseEntity entityResponse = await VendorInvoiceTxnRepository.SearchVendorInvoiceTxnAsync(request);
            VendorInvoiceTxnSearchResponse lookUpReadResponse = mapper.Map<VendorInvoiceTxnSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }


        public async Task<IResponseWrapper<VendorPaymentSearchResponse>> SearchPaymentInvoiceTxnAsync(VendorInvoicePaymentSearchRequest requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorPaymentSearchResponse>();

            VendorInvoiceTxnSearchResponseEntity entityResponse = await VendorInvoiceTxnRepository.SearchPaymentInvoiceTxnAsync(requestModel);
            VendorPaymentSearchResponse lookUpReadResponse = mapper.Map<VendorPaymentSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }


        public async Task<IResponseWrapper<VendorInvoiceTxnReadResponseModel>> UpdateVendorInvoiceTxnAsync(VendorInvoiceTxnUpdateRequestModel requestModel, int id)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceTxnReadResponseModel>();

            VendorInvoiceTxnEntity? VendorInvoiceTxnEntity = await VendorInvoiceTxnRepository.FindAsync(id);

            if (VendorInvoiceTxnEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }
            else
            {
                mapper.Map(requestModel, VendorInvoiceTxnEntity);
                if (requestModel.status == Status.Inactive.ToString() && VendorInvoiceTxnEntity.Status != Status.Active.ToString())
                {
                    VendorInvoiceTxnEntity.InactiveDate = DateTime.Now;
                }
                var VendorInvoiceTxnResponse = await VendorInvoiceTxnRepository.UpdateAsync(VendorInvoiceTxnEntity);

                VendorInvoiceTxnReadResponseModel VendorInvoiceTxnSearchResponse = mapper.Map<VendorInvoiceTxnReadResponseModel>(VendorInvoiceTxnResponse);
                wrapper.Response = VendorInvoiceTxnSearchResponse;
            }
            return wrapper;
        }


        public async Task<IResponseWrapper<VendorInvoiceTxnCreateResponseModel>> CreateVendorInvoiceTxnAsync(VendorInvoiceTxnRequestModel requestModel)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceTxnCreateResponseModel>();

            VendorInvoiceTxnEntity? VendorInvoiceTxnEntity = await VendorInvoiceTxnRepository.IsExistsAsync(requestModel.description);

            if (VendorInvoiceTxnEntity != null)
            {
                wrapper.Messages.Add(Messages.AlreadyExists.ToDetailModel(requestModel.description.ToString()));
            }
            else
            {
                VendorInvoiceTxnEntity entity = mapper.Map<VendorInvoiceTxnEntity>(requestModel);

                entity.Status = Status.Active.ToString();
                entity.CreationDate = DateTime.Now;
                entity.LastUpdateDate = DateTime.Now;


                int id = await VendorInvoiceTxnRepository.AddAsync(entity);

                wrapper.Response = new VendorInvoiceTxnCreateResponseModel()
                {
                    Id = id
                };
            }
            return wrapper;
        }

        public async Task<IResponseWrapper<VendorInvoiceTxnCreateResponseModel>> AddPaymentDetailsTxnAsync(VendorInvoicePaymentRequest requestModel)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceTxnCreateResponseModel>();

            var invoices = await VendorInvoiceTxnRepository.GetInvoicesByIdsAsync(requestModel.VendorInvoiceIds);

            if (invoices == null || !invoices.Any())
            {
                return wrapper;
            }

            List<VendorPaymentInvoiceEntity> paymentEntities = new List<VendorPaymentInvoiceEntity>();

            foreach (var invoice in invoices)
            {
                foreach (var paymentDetail in requestModel.PaymentDetails)
                {
                    paymentEntities.Add(new VendorPaymentInvoiceEntity
                    {
                        VendorInvoiceTxnID = invoice.Id,
                        paymentDate = paymentDetail.paymentDate,
                        bankID = paymentDetail.bankID,
                        paymentCurrency = paymentDetail.paymentCurrency,
                        rate = invoice.TotalAmount,
                        quantity = paymentDetail.quantity,
                        oWRMNo1 = paymentDetail.oWRMNo1, 
                        paymentAmount = invoice.TotalAmount * paymentDetail.quantity,
                        bankcharges = (invoice.TotalAmount / paymentDetail.rate) * paymentDetail.bankcharges,
                        totalAmountInr = (invoice.TotalAmount * paymentDetail.quantity) + ((invoice.TotalAmount / paymentDetail.rate)) * (paymentDetail.bankcharges),
                        PaymentStatus = "completed"
                    });
                }
            }

            await VendorInvoiceTxnRepository.SaveVendorPaymentsAsync(paymentEntities);

            wrapper.Response = new VendorInvoiceTxnCreateResponseModel()
            {
                Id = 1
            };
            return wrapper;


        }

    }
}
