using Models.RequestModels.Masters.Bank;
using Models.ResponseModels.Masters.Bank;
using Utilities;
namespace BusinessLogic.Interfaces.Masters
{
    public interface IBankService
    {
        Task<IResponseWrapper<BankReadResponseModel>> GetBankAsync(int bankId);
        Task<IResponseWrapper<BankSearchResponseModel>> SearchBankAsync(BankSearchRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<BankReadResponseModel>> UpdateBankAsync(BankUpdateRequestModel requestModel, int bankId);
       
    }
}
