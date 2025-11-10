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

        // VendorInvoiceTxnService.cs: AddPaymentDetailsTxnAsync (FINAL & SIMPLIFIED)

        // VendorInvoiceTxnService.cs: AddPaymentDetailsTxnAsync (FINAL & SIMPLIFIED)

        public async Task<IResponseWrapper<VendorInvoiceTxnCreateResponseModel>> AddPaymentDetailsTxnAsync(VendorInvoicePaymentRequest requestModel)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceTxnCreateResponseModel>();

            if (requestModel.PaymentDetails == null || !requestModel.PaymentDetails.Any())
            {
                return wrapper;
            }

            List<VendorPaymentInvoiceEntity> paymentEntities = new List<VendorPaymentInvoiceEntity>();

            // Loop over the FINAL, calculated transactions sent by the frontend.
            foreach (var paymentDetail in requestModel.PaymentDetails)
            {
                if (paymentDetail.VendorInvoiceId == null) continue;

                // 1. Read the calculated values directly from the frontend payload:
                // 'rate' holds the exact Forex amount being paid (Remaining/Partial).
                decimal forexAmountPaid = paymentDetail.rate ?? 0;
                decimal roe = paymentDetail.quantity ?? 0;
                decimal bankCharges = paymentDetail.bankcharges ?? 0;

                // 2. Calculate final INR amount (for DB record)
                decimal totalAmountInr = (forexAmountPaid * roe) + bankCharges;

                paymentEntities.Add(new VendorPaymentInvoiceEntity
                {
                    VendorInvoiceTxnID = paymentDetail.VendorInvoiceId.Value,
                    paymentDate = paymentDetail.paymentDate,
                    bankID = paymentDetail.bankID,
                    paymentCurrency = paymentDetail.paymentCurrency,
                    oWRMNo1 = paymentDetail.oWRMNo1,
                    rate = forexAmountPaid,
                    quantity = paymentDetail.quantity,
                    paymentAmount = forexAmountPaid,
                    bankcharges = bankCharges,
                    totalAmountInr = totalAmountInr
                });
            }

             await VendorInvoiceTxnRepository.SaveVendorPaymentsAsync(paymentEntities);

            wrapper.Response = new VendorInvoiceTxnCreateResponseModel() { Id = 1 };
            return wrapper;
        }

        public async Task<IResponseWrapper<VendorInvoiceTxnSearchResponse>> SearchVendorInvoiceTxnAsync1(VendorInvoiceTxnSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<VendorInvoiceTxnSearchResponse>();

            VendorInvoiceTxnSearchRequestEntity? request = mapper.Map<VendorInvoiceTxnSearchRequestEntity>(requestModel);

            VendorInvoiceTxnSearchResponseEntity entityResponse = await VendorInvoiceTxnRepository.SearchVendorInvoiceTxnAsync1(request);
            VendorInvoiceTxnSearchResponse lookUpReadResponse = mapper.Map<VendorInvoiceTxnSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }

    }
}
