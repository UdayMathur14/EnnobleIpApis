using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters.Transaction
{
    public class TransactionSearchResponse : SearchResponseBase<TransactionReadResponseModel>
    {
        public List<TransactionReadResponseModel> Transactions => base.Results;
    }
}
