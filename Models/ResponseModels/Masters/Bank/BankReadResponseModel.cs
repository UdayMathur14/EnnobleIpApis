namespace Models.ResponseModels.Masters.Bank
{
    public class BankReadResponseModel : BaseResponseModel
    {
        public string? BankName { get; set; }
        public string? BankAddress1 { get; set; }
        public string? BankAddress2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? BankContactNo { get; set; }
        public string? BankEmailId { get; set; }
        public string? BankBranch { get; set; }
        public string IFSCCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string? AccountType { get; set; }

    }
}
