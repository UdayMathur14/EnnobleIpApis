namespace Models.RequestModels.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceReportSearchRequestModel
    {
        public DateTime? FromDate  { get; set; }
        public DateTime? ToDate  { get; set; }
        public string? ApplicationNumber { get; set; }
        public string? ClientInvoiceNumber { get; set; }
        public string? Status { get; set; }
    }
}
