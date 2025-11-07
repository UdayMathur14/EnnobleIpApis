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

            // 1. Fetch all selected invoices from DB
            var invoices = (await VendorInvoiceTxnRepository.GetInvoicesByIdsAsync(requestModel.VendorInvoiceIds))?.ToList();

            if (invoices == null || !invoices.Any() || requestModel.PaymentDetails == null || !requestModel.PaymentDetails.Any())
            {
                // Handle invalid request or no invoices
                return wrapper;
            }

            // Determine the payment type (assuming all details have the same isPartial flag)
            var isPartialPayment = requestModel.PaymentDetails.First().isPartial;
            List<VendorPaymentInvoiceEntity> paymentEntities = new List<VendorPaymentInvoiceEntity>();

            if (!isPartialPayment)
            {
                // --- SCENARIO 1: FULL PAYMENT ---
                // Expecting only ONE payment detail entry in the list
                var masterPaymentDetail = requestModel.PaymentDetails.First();
                var totalSelectedAmount = invoices.Sum(i => i.TotalAmount); // Use DB value for security/accuracy

                foreach (var invoice in invoices)
                {
                    // Distributed Bank Charges Calculation: (Invoice Total / Total Selected) * Total Bank Charges
                    decimal? proportion = totalSelectedAmount > 0 ? invoice.TotalAmount / totalSelectedAmount : 0;
                    decimal? distributedBankCharges = (masterPaymentDetail.bankcharges ?? 0) * proportion;

                    // Final INR Amount Calculation
                    decimal? finalInrAmount = (invoice.TotalAmount * (masterPaymentDetail.quantity ?? 0)) + distributedBankCharges;

                    paymentEntities.Add(new VendorPaymentInvoiceEntity
                    {
                        VendorInvoiceTxnID = invoice.Id,
                        paymentDate = masterPaymentDetail.paymentDate,
                        bankID = masterPaymentDetail.bankID,
                        paymentCurrency = masterPaymentDetail.paymentCurrency,
                        oWRMNo1 = masterPaymentDetail.oWRMNo1,

                        // Fields specific to Full Payment
                        rate = masterPaymentDetail.rate,           // Total Forex Amount
                        quantity = masterPaymentDetail.quantity,   // ROE

                        // Per-invoice calculated values
                        bankcharges = distributedBankCharges,
                        paymentAmount = invoice.TotalAmount,       // Full Invoice Amount is being paid
                        totalAmountInr = finalInrAmount,
                        PaymentStatus = "completed"
                    });
                }
            }
            else // isPartialPayment == true
            {
                // --- SCENARIO 2: PARTIAL PAYMENT ---
                // Expecting multiple payment details, one per invoice.

                foreach (var paymentDetail in requestModel.PaymentDetails)
                {
                    var invoice = invoices.FirstOrDefault(i => i.Id == paymentDetail.VendorInvoiceId);

                    if (invoice != null)
                    {
                        // Validation: Though done on frontend, good practice to re-validate here
                        if ((paymentDetail.rate ?? 0) > invoice.TotalAmount)
                        {
                            // Log error or set error wrapper, do not process
                            continue;
                        }

                        // Final INR Calculation (Partial Amount * ROE + Individual Bank Charges)
                        decimal finalInrAmount = (paymentDetail.rate ?? 0) * (paymentDetail.quantity ?? 0) + (paymentDetail.bankcharges ?? 0);

                        paymentEntities.Add(new VendorPaymentInvoiceEntity
                        {
                            VendorInvoiceTxnID = invoice.Id,
                            paymentDate = paymentDetail.paymentDate,
                            bankID = paymentDetail.bankID,
                            paymentCurrency = paymentDetail.paymentCurrency,
                            oWRMNo1 = paymentDetail.oWRMNo1,

                            // Fields specific to Partial Payment
                            rate = paymentDetail.rate,        // Partial Amount entered by user (used as 'rate' field in frontend)
                            quantity = paymentDetail.quantity, // ROE
                            bankcharges = paymentDetail.bankcharges, // Individual Bank Charges
                            paymentAmount = paymentDetail.rate,      // Partial Amount is the payment amount
                            totalAmountInr = finalInrAmount,
                            PaymentStatus = "partial" // Set status to "partial"
                        });
                    }
                }
            }

            // 3. Save the prepared entities
            await VendorInvoiceTxnRepository.SaveVendorPaymentsAsync(paymentEntities);

            wrapper.Response = new VendorInvoiceTxnCreateResponseModel()
            {
                Id = 1 // Or return the ID of the main transaction record if you create one
            };
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
