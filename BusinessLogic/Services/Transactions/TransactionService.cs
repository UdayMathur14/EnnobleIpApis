using AutoMapper;
using BusinessLogic.Interfaces.Transactions;
using DataAccess.Domain.Masters.Transaction;
using DataAccess.Interfaces.Transactions;
using Models.RequestModels.Masters.Transaction;
using Models.ResponseModels.Masters.Transaction;
using Models.ResponseModels.Transactions.Transaction;
using Utilities;
using Utilities.Constants;
using Utilities.Extensions;
using Utilities.Implementation;

namespace BusinessLogic.Services.Transactions
{
    internal class TransactionService(ITransactionRepository TransactionRepository, IMapper mapper) : ITransactionService
    {
        public async Task<IResponseWrapper<TransactionReadResponseModel>> GetTransactionAsync(int id)
        {
            var wrapper = new ResponseWrapper<TransactionReadResponseModel>();
            TransactionEntity? TransactionEntity = await TransactionRepository.FindAsync(id);

            if (TransactionEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }

            TransactionReadResponseModel response = mapper.Map<TransactionReadResponseModel>(TransactionEntity);
            wrapper.Response = response;

            return wrapper;
        }


        public async Task<IResponseWrapper<TransactionSearchResponse>> SearchTransactionAsync(TransactionSearchRequestModel requestModel, string? offset, string count)
        {
            var wrapper = new ResponseWrapper<TransactionSearchResponse>();

            TransactionSearchRequestEntity? request = mapper.Map<TransactionSearchRequestEntity>(requestModel);

            TransactionSearchResponseEntity entityResponse = await TransactionRepository.SearchTransactionAsync(request);
            TransactionSearchResponse lookUpReadResponse = mapper.Map<TransactionSearchResponse>(entityResponse);

            wrapper.Response = lookUpReadResponse;

            return wrapper;
        }


        public async Task<IResponseWrapper<TransactionReadResponseModel>> UpdateTransactionAsync(TransactionUpdateRequestModel requestModel, int id)
        {
            var wrapper = new ResponseWrapper<TransactionReadResponseModel>();

            TransactionEntity? TransactionEntity = await TransactionRepository.FindAsync(id);

            if (TransactionEntity == null)
            {
                wrapper.Messages.Add(Messages.EntityNotFound.ToDetailModel(id.ToString()));
            }
            else
            {
                mapper.Map(requestModel, TransactionEntity);
                if (requestModel.Status == Status.Inactive.ToString() && TransactionEntity.Status != Status.Active.ToString())
                {
                    TransactionEntity.InactiveDate = DateTime.Now;
                }
                var TransactionResponse = await TransactionRepository.UpdateAsync(TransactionEntity);

                TransactionReadResponseModel TransactionSearchResponse = mapper.Map<TransactionReadResponseModel>(TransactionResponse);
                wrapper.Response = TransactionSearchResponse;
            }
            return wrapper;
        }


        public async Task<IResponseWrapper<TransactionCreateResponseModel>> CreateTransactionAsync(TransactionRequestModel requestModel)
        {
            var wrapper = new ResponseWrapper<TransactionCreateResponseModel>();

            TransactionEntity? TransactionEntity = await TransactionRepository.IsExistsAsync(requestModel.Description);

            if (TransactionEntity != null)
            {
                wrapper.Messages.Add(Messages.AlreadyExists.ToDetailModel(requestModel.Description.ToString()));
            }
            else
            {
                TransactionEntity entity = mapper.Map<TransactionEntity>(requestModel);

                entity.Status = Status.Active.ToString();
                entity.CreationDate = DateTime.Now;
                entity.LastUpdateDate = DateTime.Now;


                int id = await TransactionRepository.AddAsync(entity);

                wrapper.Response = new TransactionCreateResponseModel()
                {
                    Id = id
                };
            }
            return wrapper;
        }


    }
}
