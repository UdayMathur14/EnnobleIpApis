namespace Models.RequestModels.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceTxnSearchRequestModel
    {
        //public List<VendorInvoiceFeeRequestModel>? Fees { get; set; }
        public string? ApplicationNumber { get; set; }
        public string? ClientInvoiceNumber { get; set; }
        public string? Status { get; set; }
    }
    //public class VendorInvoiceFeeRequestModel
    //{
    //    public string? FeeType { get; set; }  // e.g., "Professional Fee", "Govt Fee"
    //    public string? Country { get; set; }  // e.g., "IN", "US"
    //    public decimal? Amount { get; set; }  // e.g., 1000.00
    //}
}
