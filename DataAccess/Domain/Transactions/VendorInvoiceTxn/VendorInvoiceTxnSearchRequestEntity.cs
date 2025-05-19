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
        public string? ApplicationNumber { get; set; }
        public string? ClientInvoiceNumber { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
