using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain.Masters.Vendor
{
    public class VendorSearchRequestEntity
    {
        public string? VendorName { get; set; }
        public string? VendorCode { get; set; }
        public string? Status { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
