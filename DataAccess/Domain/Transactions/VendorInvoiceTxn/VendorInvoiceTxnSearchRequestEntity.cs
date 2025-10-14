using Models.ResponseModels.Masters.Customer;
using Models.ResponseModels.Masters.Vendor;

namespace DataAccess.Domain.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceTxnSearchRequestEntity
    {
        public string? VendorName { get; set; }
        public string? ApplicationNumber { get; set; }
        public string? ClientInvoiceNumber { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
