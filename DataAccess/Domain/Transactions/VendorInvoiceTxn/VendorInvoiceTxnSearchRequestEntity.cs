using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain.Masters.VendorInvoiceTxn
{
    public class VendorInvoiceTxnSearchRequestEntity
    {
        public string? VendorInvoiceTxnName { get; set; }
        public string? VendorInvoiceTxnCode { get; set; }
        public string? VendorInvoiceTxnType { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
