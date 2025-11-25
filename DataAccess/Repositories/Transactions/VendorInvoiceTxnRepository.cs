using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Transactions.VendorInvoiceTxn;
using DataAccess.Interfaces.VendorInvoiceTxn;
using Microsoft.EntityFrameworkCore;
using Models.RequestModels.Transactions.VendorInvoiceTxn;
using Models.ResponseModels.Masters.VendorInvoiceTxn;
using System.Linq;
using Utilities;

namespace DataAccess.Repositories.VendorInvoiceTxns
{
    internal class VendorInvoiceTxnRepository(ApplicationDbContext _context) : IVendorInvoiceTxnRepository
    {
        public async Task<int> AddAsync(VendorInvoiceTxnEntity entity)
        {
            if (entity.FeeDetails != null && entity.FeeDetails.Any())
            {
                foreach (var fee in entity.FeeDetails)
                {
                    fee.VendorInvoiceTxnEntity = entity;
                }
            }
            _context.VendorInvoiceTxnEntity.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<VendorInvoiceTxnEntity?> FindAsync(int id)
        {
            return await
                _context.VendorInvoiceTxnEntity
                .Include(x => x.FeeDetails)
                .Include(x => x.VendorApplicantNames)
                .Include(x => x.SalesInvoiceDetails)
                .Include(x => x.VendorEntity)
                .Include(x => x.CustomerEntity)
                .Include(x => x.PaymentInvoiceDetails)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        //public async Task<VendorInvoiceTxnEntity?> IsExistsAsync(string? ve)
        //{
        //    return null;
        //}

        public async Task<VendorInvoiceTxnSearchResponseEntity> SearchVendorInvoiceTxnAsync(VendorInvoiceTxnSearchRequestEntity request)
        {
            var response = new VendorInvoiceTxnSearchResponseEntity();

            var query = _context.VendorInvoiceTxnEntity
                 .Include(x => x.VendorEntity)
                .Include(x => x.CustomerEntity).OrderByDescending(x=>x.InvoiceDate).
                AsQueryable();

            var Vendors = await _context.VendorInvoiceTxnEntity
                    .Where(a => a.VendorEntity != null && a.VendorEntity.VendorName != null)
                    .Select(a => a.VendorEntity.VendorName)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var ClientInvoiceNo = await _context.VendorInvoiceTxnEntity
                       .Select(a => a.ClientInvoiceNo)
                       .Distinct()
                       .ToListAsync();

            var ApplicationNumber = await _context.VendorInvoiceTxnEntity
                       .Select(a => a.ApplicationNumber)
                       .Distinct()
                       .ToListAsync();

            var Status = await _context.VendorInvoiceTxnEntity
                       .Select(a => a.Status)
                       .Distinct()
                       .ToListAsync();

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status!.ToLower().Equals(request.Status.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ApplicationNumber))
            {
                query = query.Where(t => t.ApplicationNumber!.ToLower().Contains(request.ApplicationNumber.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ClientInvoiceNumber))
            {
                query = query.Where(t => t.ClientInvoiceNo!.ToLower().Contains(request.ClientInvoiceNumber.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.VendorName))
            {
                query = query.Where(t => t.VendorEntity.VendorName!.ToLower().Contains(request.VendorName.ToLower()));
            }

            if (request.Count == 0)
            {
                response.VendorInvoiceTxn = await query.ToListAsync();
                // If Count is 0, we should return an empty result set and set paging values appropriately
                response.Paging.TotalPages = 0;
                response.Paging.CurrentPage = 0;
                response.Paging.Results = 0;
                response.Paging.NextOffset = null;
                response.Paging.NextPage = null;
                response.Paging.PrevPage = null;
            }
            else
            {
                response.Paging.Total = query.AsNoTracking().Count();
                response.VendorInvoiceTxn = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.VendorInvoiceTxn.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }
            response.Filters = new Dictionary<string, List<string>>
            {
                { "Status", Status },
                { "ApplicationNumber", ApplicationNumber },
                { "ClientInvoiceNo", ClientInvoiceNo },
                { "Vendors", Vendors }
            };

            return response;
        }

        public async Task<VendorInvoiceTxnEntity> UpdateAsync(VendorInvoiceTxnEntity VendorInvoiceTxnEntity)
        {
            _context.VendorInvoiceTxnEntity.Update(VendorInvoiceTxnEntity);
            await _context.SaveChangesAsync();

            return VendorInvoiceTxnEntity;
        }

        public async Task<List<VendorInvoiceTxnEntity>> GetInvoicesByIdsAsync(List<int> invoiceIds)
        {
            return await _context.VendorInvoiceTxnEntity
                                 .Where(x => invoiceIds.Contains(x.Id))
                                 .ToListAsync();
        }

        public async Task SaveVendorPaymentsAsync(List<VendorPaymentInvoiceEntity> payments)
        {
            await _context.PaymentInvoiceEntity.AddRangeAsync(payments);
            await _context.SaveChangesAsync();
        }

        public async Task<VendorInvoiceTxnSearchResponseEntity> SearchVendorInvoiceTxnAsync1(VendorInvoiceTxnSearchRequestEntity request)
        {
            var response = new VendorInvoiceTxnSearchResponseEntity();

            // 1. Setup the base query and Eager Loading
            var query = _context.VendorInvoiceTxnEntity
                .Include(x => x.VendorEntity)
                .Include(x => x.CustomerEntity).OrderByDescending(x=>x.InvoiceDate)
                .AsQueryable();

            // 2. Apply Filters and Fetch Lookups (Unchanged)
            var Vendors = await _context.VendorInvoiceTxnEntity
                .Where(a => a.VendorEntity != null && a.VendorEntity.VendorName != null)
                .Select(a => a.VendorEntity.VendorName)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

            var ClientInvoiceNo = await _context.VendorInvoiceTxnEntity
                .Select(a => a.ClientInvoiceNo)
                .Distinct()
                .ToListAsync();

            var ApplicationNumber = await _context.VendorInvoiceTxnEntity
                .Select(a => a.ApplicationNumber)
                .Distinct()
                .ToListAsync();

            var Status = await _context.VendorInvoiceTxnEntity
                .Select(a => a.Status)
                .Distinct()
                .ToListAsync();

            // Apply filtering to the query
            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status!.ToLower().Equals(request.Status.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ApplicationNumber))
            {
                query = query.Where(t => t.ApplicationNumber!.ToLower().Contains(request.ApplicationNumber.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ClientInvoiceNumber))
            {
                query = query.Where(t => t.ClientInvoiceNo!.ToLower().Contains(request.ClientInvoiceNumber.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.VendorName))
            {
                query = query.Where(t => t.VendorEntity.VendorName!.ToLower().Contains(request.VendorName.ToLower()));
            }

            // 3. 🔥 CORE LOGIC: Project and Calculate Remaining Balance
            var calculatedQuery = query
                .Select(invoice => new VendorInvoiceTxnEntity
                {
                    // --- Map Core Data (MUST map all fields needed by the UI) ---
                    Id = invoice.Id,
                    TotalAmount = invoice.TotalAmount,
                    InvoiceDate = invoice.InvoiceDate,
                    ClientInvoiceNo = invoice.ClientInvoiceNo,
                    DueDateAsPerInvoice = invoice.DueDateAsPerInvoice,
                    Status = invoice.Status,
                    VendorEntity = invoice.VendorEntity,
                    CustomerEntity = invoice.CustomerEntity,
                    // ... map all other original properties needed by the UI ...

                    // --- Calculation ---
                    TotalPaidAmount = _context.PaymentInvoiceEntity
                        .Where(p => p.VendorInvoiceTxnID == invoice.Id)
                        .Sum(p => p.rate) ?? 0, // Assuming correct property name is PaymentAmount or paymentAmount

                    RemainingBalance = invoice.TotalAmount - (
                        _context.PaymentInvoiceEntity
                            .Where(p => p.VendorInvoiceTxnID == invoice.Id)
                            .Sum(p => p.rate) ?? 0
                    )
                });

            // 4. 🔥 Final Filter: Only return invoices with a remaining balance > 0
            var finalFilteredQuery = calculatedQuery.Where(t => t.RemainingBalance > 0);

            // --- 5. Pagination and Execution (PRESERVED ORIGINAL LOGIC) ---

            // Total count must be taken from the final filtered query
            response.Paging.Total = await finalFilteredQuery.AsNoTracking().CountAsync();

            int offsetValue = request.Offset;
            int countValue = request.Count;

            if (countValue == 0) // Original check for request.Count == 0
            {
                // 🔥 MODIFIED: Use the calculated, filtered query to fetch all matching, UNPAID invoices
                response.VendorInvoiceTxn = await finalFilteredQuery.ToListAsync();

                // If Count is 0, we should return an empty result set and set paging values appropriately
                // However, your original logic in this block sets Paging values to 0, despite fetching data.
                // We stick to the original structure for the demo:
                response.Paging.TotalPages = 0;
                response.Paging.CurrentPage = 0;
                response.Paging.Results = 0;
                response.Paging.NextOffset = null;
                response.Paging.NextPage = null;
                response.Paging.PrevPage = null;
            }
            else // Original 'else' block for paginated results
            {
                // Apply Skip/Take after filtering and projection
                response.VendorInvoiceTxn = await finalFilteredQuery
                    .Skip(offsetValue)
                    .Take(countValue)
                    .ToListAsync();

                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / countValue);
                response.Paging.CurrentPage = (offsetValue / countValue) + 1;
                response.Paging.Results = response.VendorInvoiceTxn.Count();

                response.Paging.NextOffset = response.Paging.Total < offsetValue + countValue ?
                    null :
                    (offsetValue + countValue).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * countValue)}&count={countValue}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(offsetValue - countValue)}&count={countValue}" : null;
            }

            // 6. Filters (PRESERVED ORIGINAL LOGIC)
            response.Filters = new Dictionary<string, List<string>>
            {
                { "Status", Status },
                { "ApplicationNumber", ApplicationNumber },
                { "ClientInvoiceNo", ClientInvoiceNo },
                { "Vendors", Vendors }
            };
            return response;
        }

        public async Task<List<int>> CheckAndGetFullyPaidInvoicesAsync(List<int> vendorInvoiceIds)
        {
            if (vendorInvoiceIds == null || !vendorInvoiceIds.Any())
            {
                return new List<int>();
            }

            // 1. Invoices ko Group karo aur har ek ke liye Total Paid Amount nikaalo.
            var result = await _context.VendorInvoiceTxnEntity
                // Sirf unn Master Invoices ko select karo jo abhi process ho rahe hain.
                .Where(masterInvoice => vendorInvoiceIds.Contains(masterInvoice.Id))
                .Select(masterInvoice => new
                {
                    InvoiceId = masterInvoice.Id,
                    // Master Invoice ki original total amount (Forex amount).
                    OriginalTotalAmount = masterInvoice.TotalAmount,

                    // Sub-Query (SUM): Is InvoiceId se jude saare payment transactions (VendorPaymentInvoiceTable) se 
                    // 'rate' field (jo payment amount/Forex hai) ka total sum nikaalo.
                    TotalPaidAmount = _context.PaymentInvoiceEntity
                        .Where(payment => payment.VendorInvoiceTxnID == masterInvoice.Id)
                        .Sum(payment => payment.rate)
                })
                // 2. Filter: Jinka total paid amount, original amount se barabar ya zyada hai.
                .Where(x => x.TotalPaidAmount >= x.OriginalTotalAmount)
                // 3. Output: Sirf Invoice ID return karo.
                .Select(x => x.InvoiceId)
                .ToListAsync();

            return result;
        }
        public async Task UpdateInvoiceStatusToCloseAsync(List<int> vendorInvoiceIds)
        {
            if (vendorInvoiceIds == null || !vendorInvoiceIds.Any())
            {
                return;
            }

            // 🔥 FIX: vendorInvoiceIds.Contains(invoice.VendorInvoiceTxnID) hona chahiye
            var invoicesToUpdate = await _context.VendorInvoiceTxnEntity // Entity ya DbSet ka naam
                .Where(invoice => vendorInvoiceIds.Contains(invoice.Id) &&
                                  invoice.Status != "Close")
                .ToListAsync();

            if (invoicesToUpdate.Any())
            {
                foreach (var invoice in invoicesToUpdate)
                {
                    invoice.Status = "Closed";
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<VendorInvoiceTxnEntity?> IsExistsAsync(decimal? vendorID, string? clientInvoiceNo)
        {
            return await _context.VendorInvoiceTxnEntity.Where(c => c.VendorID == vendorID && c.ClientInvoiceNo == clientInvoiceNo ).FirstOrDefaultAsync();
        }
    }
}
