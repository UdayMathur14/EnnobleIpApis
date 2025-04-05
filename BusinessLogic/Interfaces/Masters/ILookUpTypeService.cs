using Models.RequestModels.Masters.LookUpType;
using Models.ResponseModels.Masters.LookUpType;
using Utilities;

namespace BusinessLogic.Interfaces.Masters
{
    public interface ILookUpTypeService
    {
        Task<IResponseWrapper<LookUpTypeReadResponseModel>> GetLookUpAsync(int id);
        Task<IResponseWrapper<LookUpTypeSearchResponse>> SearchLookUpAsync(LookUpTypeSearchRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<LookUpTypeReadResponseModel>> UpdateLookUpAsync(LookupTypeUpdateRequestModel requestModel, int id);
        Task<IResponseWrapper<LookUpTypeCreateResponseModel>> CreateLookUpAsync(LookUpTypeRequestModel requestModel);
    }
}
