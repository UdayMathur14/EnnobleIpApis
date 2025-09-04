namespace Models.RequestModels.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceReportRequestModel
    {
        public string? ApplicationNumber { get; set; }
        public string? ClientRefNumber { get; set; }
        public string? Status { get; set; }
        public string? Vendor { get; set; }
        public string? Customer { get; set; }
        public string ReportType { get; set; }

        }

}
