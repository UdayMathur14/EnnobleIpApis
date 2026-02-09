using AutoMapper;
using BusinessLogic.Interfaces.VendorInvoiceTxns;
using BusinessLogic.Rules.Enums;
using BusinessLogic.Rules.Masters.VendorInvoiceTxn.Search;
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

            var rules = new VendorInvoiceTxnSearchRules(request, offset, count);
            rules.RunRules();
            foreach (var result in rules.Results)
            {
                if (result.ResultCode == RuleResultType.Fail && result.Exception != null)
                {
                    wrapper.Messages.Add(Messages.GetErrorDetail(
                        result.Exception.Code,
                        result.Exception.Message,
                        result.Exception.Element,
                        result.Exception.Category)
                        .ToDetailModel(result.Exception.ElementValue));
                }
            }

            if (rules.Result == RuleResultType.Fail)
            {
                return wrapper;
            }

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
                if (VendorInvoiceTxnEntity.PaymentInvoiceDetails.Count() != requestModel.paymentFeeDetails.Count())
                {
                    requestModel.status = "Open";
                }

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

            VendorInvoiceTxnEntity? VendorInvoiceTxnEntity = await VendorInvoiceTxnRepository.IsExistsAsync(requestModel.vendorID,requestModel.clientInvoiceNo);

            if (VendorInvoiceTxnEntity != null)
            {
                wrapper.Messages.Add(Messages.AlreadyExists.ToDetailModel(requestModel.clientInvoiceNo.ToString()));
            }
            else
            {
                VendorInvoiceTxnEntity entity = mapper.Map<VendorInvoiceTxnEntity>(requestModel);

                entity.Status = Status.Open.ToString();
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

            if (requestModel.PaymentDetails == null || !requestModel.PaymentDetails.Any())
            {
                return wrapper;
            }

            List<VendorPaymentInvoiceEntity> paymentEntities = new List<VendorPaymentInvoiceEntity>();

            List<int> invoicesToProcess = new List<int>();

            foreach (var paymentDetail in requestModel.PaymentDetails)
            {
                if (paymentDetail.VendorInvoiceId == null) continue;
                int vendorInvoiceId = paymentDetail.VendorInvoiceId.Value;

                // --- EXISTING CODE: NO CHANGE ---
                // 1. Read the calculated values directly from the frontend payload:
                decimal forexAmountPaid = paymentDetail.rate ?? 0; // Yeh rate/paymentAmount ka kaam karega
                decimal roe = paymentDetail.quantity ?? 0;
                decimal bankCharges = paymentDetail.bankcharges ?? 0;

                // 2. Calculate final INR amount (for DB record)
                decimal totalAmountInr = (forexAmountPaid * roe) + bankCharges;

                paymentEntities.Add(new VendorPaymentInvoiceEntity
                {
                    VendorInvoiceTxnID = vendorInvoiceId,
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

                if (!invoicesToProcess.Contains(vendorInvoiceId))
                {
                    invoicesToProcess.Add(vendorInvoiceId);
                }
            }

            await VendorInvoiceTxnRepository.SaveVendorPaymentsAsync(paymentEntities);

            if (invoicesToProcess.Any())
            {
                // Step 1: Repository se poochho ki in mein se kaunse invoices ka Remaining Balance zero ho gaya hai.
                // Yeh assume karta hai ki SaveVendorPaymentsAsync ke baad DB mein Remaining Balance update ho chuka hai.
                List<int> fullyPaidInvoiceIds = await VendorInvoiceTxnRepository.CheckAndGetFullyPaidInvoicesAsync(invoicesToProcess);

                if (fullyPaidInvoiceIds.Any())
                {
                    // Step 2: Un invoices ka status 'Close' kar do.
                    await VendorInvoiceTxnRepository.UpdateInvoiceStatusToCloseAsync(fullyPaidInvoiceIds);
                }
            }

            // --- EXISTING CODE: NO CHANGE ---
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
