using DataAccess.Domain.Masters;
using Models.RequestModels.Masters;
using Models.ResponseModels.Masters;
using Models.ResponseModels.Masters.LookUp;
using Utilities;

namespace BusinessLogic.Interfaces.Masters
{
    public interface ILookUpService
    {
        Task<IResponseWrapper<LookUpReadResponseModel>> GetLookUpAsync(int id);
        Task<IResponseWrapper<LookUpSearchResponse>> SearchLookUpAsync(LookUpSearchRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<LookUpReadResponseModel>> UpdateLookUpAsync(LookupUpdateRequestModel requestModel, int id);
        Task<IResponseWrapper<LookUpCreateResponseModel>> CreateLookUpAsync(LookUpRequestModel requestModel);
        Task<IResponseWrapper<LookUpSearchResponse>> SearchLookUpByTypeAsync(string type);
    }
}
