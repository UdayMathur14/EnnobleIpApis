using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Transactions.VendorInvoiceTxn;
using Models.RequestModels.Transactions.VendorInvoiceTxn;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
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
        Task<VendorInvoiceTxnSearchResponseEntity> SearchVendorInvoiceTxnAsync1(VendorInvoiceTxnSearchRequestEntity request);
        Task<VendorInvoiceTxnEntity?> IsExistsAsync(string? code);
        Task<List<VendorInvoiceTxnEntity>> GetInvoicesByIdsAsync(List<int> invoiceIds);
        Task SaveVendorPaymentsAsync(List<VendorPaymentInvoiceEntity> payments);
        Task<VendorInvoiceTxnSearchResponseEntity> SearchPaymentInvoiceTxnAsync(VendorInvoicePaymentSearchRequest request);
    }
}
