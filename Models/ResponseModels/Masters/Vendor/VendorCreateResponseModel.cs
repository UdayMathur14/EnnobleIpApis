using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters.Vendor
{
    public class VendorCreateResponseModel: ResponseMessage
    {
        public int Id { get; set; }

        public VendorCreateResponseModel() { }

        public VendorCreateResponseModel(int id)
        {
            Id = id;
        }
    }
}
