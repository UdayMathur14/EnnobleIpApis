namespace DataAccess.Domain.Masters.LookUp
{
    public class LookUpSearchRequestEntity
    {
        public string? LookupType { get; set; }
        public string? Code { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
