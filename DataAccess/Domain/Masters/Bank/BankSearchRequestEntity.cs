namespace DataAccess.Domain.Masters.Bank
{
    public class BankSearchRequestEntity
    {
        public string? BankName { get; set; }
        public string? AccountType { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
