

using System.ComponentModel.DataAnnotations;

namespace Models.RequestModels.Masters.Bank
{
    public class BankRequestModel : BaseRequestModel
    {
        
        [Required]
        [StringLength(255)]
        public string BankName { get; set; }

        [StringLength(255)]
        public string? BankBranch { get; set; }

        [Required]
        [StringLength(20)]
        public string IFSCCode { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string AccountHolderName { get; set; }

        [StringLength(50)]
        public string? AccountType { get; set; }

        public string? BankAddress1 { get; set; }
        public string? BankAddress2 { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string? BankContactNo { get; set; }
        public string? BankEmailId { get; set; }
    }
}
