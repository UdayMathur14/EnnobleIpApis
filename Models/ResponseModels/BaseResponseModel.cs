using Utilities;

namespace Models.ResponseModels
{
    public class BaseResponseModel : IResponseMessage
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? Status { get; set; }
        public MessageStatusModel? MessageStatus { get; set; }
    }
}
