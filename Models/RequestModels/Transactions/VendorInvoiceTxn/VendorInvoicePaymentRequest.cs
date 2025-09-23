using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Transactions.VendorInvoiceTxn
{
    public class VendorInvoicePaymentRequest
    {
        public List<int>? VendorInvoiceIds { get; set; }  // Selected invoice IDs
        public List<PaymentDetailDto>? PaymentDetails { get; set; }
    }
    public class PaymentDetailDto
    {
        public int BankId { get; set; }
        public decimal RateOfExchange { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public decimal Amount { get; set; }
    }
}
