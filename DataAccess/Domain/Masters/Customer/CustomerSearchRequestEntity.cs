namespace DataAccess.Domain.Masters.Customer
{
    public class CustomerSearchRequestEntity
    {
        public string? CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerType { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
