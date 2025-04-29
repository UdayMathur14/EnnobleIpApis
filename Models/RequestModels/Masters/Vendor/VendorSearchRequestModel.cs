using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RequestModels.Masters.Vendor
{
    public class VendorSearchRequestModel
    {
        public string? VendorName { get; set; }  
        public string? VendorCode { get; set; }
        public string? VendorType { get; set; }
        public string? Status { get; set; }
    }
}
