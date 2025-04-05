using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters.Bank
{
    public class BankCreateResponseModel : ResponseMessage
    {
        public int Id { get; set; }
        public BankCreateResponseModel() { }
        public BankCreateResponseModel(int id)
        {
            Id = id;
        }
    }
}
