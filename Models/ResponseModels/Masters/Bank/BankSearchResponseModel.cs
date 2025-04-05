using Models.ResponseModels.BaseResponseSetup;
namespace Models.ResponseModels.Masters.Bank
{
    public class BankSearchResponseModel : SearchResponseBase<BankReadResponseModel>
    {
        public List<BankReadResponseModel> Banks => base.Results;
    }
}


