using Models.RequestModels.Masters.Transaction;
using Models.ResponseModels.Masters.Transaction;
using Models.ResponseModels.Transactions.Transaction;
using Utilities;

namespace BusinessLogic.Interfaces.Transactions
{
    public interface ITransactionService
    {
        Task<IResponseWrapper<TransactionReadResponseModel>> GetTransactionAsync(int id);
        Task<IResponseWrapper<TransactionSearchResponse>> SearchTransactionAsync(TransactionSearchRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<TransactionReadResponseModel>> UpdateTransactionAsync(TransactionUpdateRequestModel requestModel, int id);
        Task<IResponseWrapper<TransactionCreateResponseModel>> CreateTransactionAsync(TransactionRequestModel requestModel);
    }
}
