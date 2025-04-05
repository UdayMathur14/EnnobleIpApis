using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters.Vendor
{
    public class VendorSearchResponse : SearchResponseBase<VendorReadResponseModel>
    {
        public List<VendorReadResponseModel> Vendors => base.Results;
    }
}
