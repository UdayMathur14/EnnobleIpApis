namespace Models.RequestModels.Masters.Bank
{
    public class BankUpdateRequestModel : BaseRequestModel
    {
        public string? BankContactNo { get; set; }
        public string? BankEmailId { get; set; }
        public string? Status { get; set; }
        
    }
}
