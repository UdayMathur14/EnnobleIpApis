using DataAccess.Domain.Masters.VendorInvoiceTxn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces.VendorInvoiceTxn
{
    public interface IVendorInvoiceTxnRepository : IRepository<VendorInvoiceTxnEntity>
    {
        Task<VendorInvoiceTxnSearchResponseEntity> SearchVendorInvoiceTxnAsync(VendorInvoiceTxnSearchRequestEntity request);
        Task<VendorInvoiceTxnEntity?> IsExistsAsync(string? code);
    }
}
