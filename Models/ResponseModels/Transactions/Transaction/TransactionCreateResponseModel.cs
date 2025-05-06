using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters.Transaction
{
    public class TransactionCreateResponseModel: ResponseMessage
    {
        public int Id { get; set; }

        public TransactionCreateResponseModel() { }

        public TransactionCreateResponseModel(int id)
        {
            Id = id;
        }
    }
}
