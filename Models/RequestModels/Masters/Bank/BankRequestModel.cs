

using System.ComponentModel.DataAnnotations;

namespace Models.RequestModels.Masters.Bank
{
    public class BankRequestModel : BaseRequestModel
    {
        public string? BankName { get; set; }
        public string? BankBranch { get; set; }
        public string? IFSCCode { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountType { get; set; }
        public string? BankAddress1 { get; set; }
        public string? BankAddress2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? BankContactNo { get; set; }
        public string? BankEmailId { get; set; }
    }
}
