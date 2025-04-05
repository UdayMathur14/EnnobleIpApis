using Models.RequestModels;

namespace DataAccess.Domain.Masters.Customer
{
    public class CustomerRequestModel : BaseRequestModel
    {
        public string? CustomerContactNo { get; set; }
        public string? CustomerEmailId { get; set; }
        public string? Status { get; set; }
    }
}
