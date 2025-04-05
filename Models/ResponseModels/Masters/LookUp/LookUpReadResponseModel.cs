using Models.ResponseModels.Masters.LookUpType;

namespace Models.ResponseModels.Masters
{
    public class LookUpReadResponseModel : BaseResponseModel
    {
        public string? Code { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public CommonNestedResponseModel? LookUpType { get; set; }
    }
}