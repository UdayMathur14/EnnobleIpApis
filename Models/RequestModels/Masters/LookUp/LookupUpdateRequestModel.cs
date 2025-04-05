using Models.RequestModels;

namespace DataAccess.Domain.Masters
{
    public class LookupUpdateRequestModel: BaseRequestModel
    {
        public string? Code { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }
}
