namespace DataAccess.Domain.Masters.Bank
{
    public class BankSearchRequestEntity
    {
        public string? BankCode { get; set; }
        public string? BankName { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
