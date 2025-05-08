using Models.ResponseModels.BaseResponseSetup;
using Models.ResponseModels.Transactions.Transaction;

namespace Models.ResponseModels.Masters.Transaction
{
    public class TransactionSearchResponse : SearchResponseBase<TransactionReadResponseModel>
    {
        public List<TransactionReadResponseModel> Transactions => base.Results;
    }
}
