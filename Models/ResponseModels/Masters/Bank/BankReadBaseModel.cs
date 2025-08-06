namespace Models.ResponseModels.Masters.Bank
{
    public class BankReadBaseModel
    {
        public int Id { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress1 { get; set; }
        public string? BankAddress2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Postal { get; set; }
        public string? Status { get; set; }
    }
}
