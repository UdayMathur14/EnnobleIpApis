using Models.RequestModels.Masters.Vendor;
using Models.ResponseModels.Masters.Vendor;
using Utilities;

namespace BusinessLogic.Interfaces.Masters
{
    public interface IVendorService
    {
        Task<IResponseWrapper<VendorReadResponseModel>> GetVendorAsync(int id);
        Task<IResponseWrapper<VendorSearchResponse>> SearchVendorAsync(VendorSearchRequestModel requestModel, string? offset, string count);
        Task<IResponseWrapper<VendorReadResponseModel>> UpdateVendorAsync(VendorUpdateRequestModel requestModel, int id);
        Task<IResponseWrapper<VendorCreateResponseModel>> CreateVendorAsync(VendorRequestModel requestModel);
    }
}
