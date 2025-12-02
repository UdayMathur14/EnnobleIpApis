using Models.ResponseModels.Masters.Customer;
using Models.ResponseModels.Masters.Vendor;

namespace DataAccess.Domain.Masters.VendorInvoiceReport
{
    public class VendorInvoiceReportSearchRequestEntity
    {
        public string? ApplicationNumber { get; set; }
        public string? ClientRefNumber { get; set; }
        public string? Status { get; set; }
        public string? Country { get; set; }
        public string? Vendor { get; set; }
        public string? Customer { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
