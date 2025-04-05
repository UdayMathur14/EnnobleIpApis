using Models.RequestModels;

namespace DataAccess.Domain.Masters
{
    public class LookUpRequestModel : BaseRequestModel
    {
        public int? TypeId { get; set; }
        public string? Code { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
    }
}
