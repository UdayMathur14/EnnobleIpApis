using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Reports.VendorInvoiceReport;
using DataAccess.Interfaces.VendorInvoiceReport;
using Microsoft.EntityFrameworkCore;
using Models.ResponseModels.Reports.VendorInvoiceReport;
using System.Linq;

namespace DataAccess.Repositories.VendorInvoiceReports
{
    internal class VendorInvoiceReportRepository(ApplicationDbContext _context) : IVendorInvoiceReportRepository
    {
        public Task<int> AddAsync(VendorInvoiceTxnEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<VendorInvoiceTxnEntity?> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VendorInvoiceReportSearchResponseEntity> SearchVendorInvoiceReportAsync(VendorInvoiceReportSearchRequestEntity request)
        {
            var response = new VendorInvoiceReportSearchResponseEntity();

            var query = _context.VendorInvoiceTxnEntity
                 .Include(x => x.VendorEntity)
                .Include(x => x.CustomerEntity).
                AsQueryable();

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
                query = query.Where(t => t.Status!.ToLower().Contains(request.Status.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ApplicationNumber))
            {
                query = query.Where(t => t.ApplicationNumber!.ToLower().Contains(request.ApplicationNumber.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ClientRefNumber))
            {
                query = query.Where(t => t.ClientInvoiceNo!.ToLower().Contains(request.ClientRefNumber.ToLower()));
            }

            if (request.Count == 0)
            {
                response.VendorInvoiceReport = await query.ToListAsync();
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
                response.VendorInvoiceReport = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.VendorInvoiceReport.Count();
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
                { "ClientInvoiceNo", ClientInvoiceNo }
            };

            return response;
        }

        public Task<VendorInvoiceTxnEntity> UpdateAsync(VendorInvoiceTxnEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<VendorInvoiceTxnSearchResponseEntity> SearchVendorInvoiceTxnAsync1(VendorInvoiceTxnSearchRequestEntity request)
        {
            var response = new VendorInvoiceTxnSearchResponseEntity();

            // 1. Setup the base query and Eager Loading
            var query = _context.VendorInvoiceTxnEntity
                .Include(x => x.VendorEntity)
                .Include(x => x.CustomerEntity).OrderByDescending(x => x.InvoiceDate)
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

        public async Task<VendorInvoiceReportSearchResponseEntity> SearchSaleInvoiceReportAsync(VendorInvoiceReportSearchRequestEntity request)
        {
            var response = new VendorInvoiceReportSearchResponseEntity();

            var query = _context.VendorInvoiceTxnEntity
                         .Include(x => x.VendorEntity)
                         .Include(x => x.SalesInvoiceDetails)
                         .AsQueryable();

            // Filter: Vendor invoices where no sales invoice exists
            query = query.Where(x => !x.SalesInvoiceDetails.Any());

            // Additional filters
            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status!.ToLower().Contains(request.Status.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ApplicationNumber))
            {
                query = query.Where(t => t.ApplicationNumber!.ToLower().Contains(request.ApplicationNumber.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ClientRefNumber))
            {
                query = query.Where(t => t.ClientInvoiceNo!.ToLower().Contains(request.ClientRefNumber.ToLower()));
            }

            // Paging
            if (request.Count == 0)
            {
                response.VendorInvoiceReport = await query.ToListAsync();
                response.Paging.TotalPages = 0;
                response.Paging.CurrentPage = 0;
                response.Paging.Results = 0;
                response.Paging.NextOffset = null;
                response.Paging.NextPage = null;
                response.Paging.PrevPage = null;
            }
            else
            {
                response.Paging.Total = await query.AsNoTracking().CountAsync();
                response.VendorInvoiceReport = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.VendorInvoiceReport.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ? null : (request.Offset + request.Count).ToString();
                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;
            }

            // Filters for frontend dropdowns
            response.Filters = new Dictionary<string, List<string>>
    {
        { "Status", await _context.VendorInvoiceTxnEntity.Select(a => a.Status).Distinct().ToListAsync() },
        { "ApplicationNumber", await _context.VendorInvoiceTxnEntity.Select(a => a.ApplicationNumber).Distinct().ToListAsync() },
        { "ClientInvoiceNo", await _context.VendorInvoiceTxnEntity.Select(a => a.ClientInvoiceNo).Distinct().ToListAsync() }
    };

            return response;
        }



        public async Task<VendorInvoiceReportSearchResponseEntity> SearchCustomerInvoiceTotalReportAsync(VendorInvoiceReportSearchRequestEntity request)
        {
            var response = new VendorInvoiceReportSearchResponseEntity();

            var query = _context.VendorInvoiceTxnEntity
                 .Include(x => x.VendorEntity)
                .Include(x => x.CustomerEntity).
                AsQueryable();

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
                query = query.Where(t => t.Status!.ToLower().Contains(request.Status.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ApplicationNumber))
            {
                query = query.Where(t => t.ApplicationNumber!.ToLower().Contains(request.ApplicationNumber.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.ClientRefNumber))
            {
                query = query.Where(t => t.ClientInvoiceNo!.ToLower().Contains(request.ClientRefNumber.ToLower()));
            }

            if (request.Count == 0)
            {
                response.VendorInvoiceReport = await query.ToListAsync();
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
                response.VendorInvoiceReport = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.VendorInvoiceReport.Count();
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
                { "ClientInvoiceNo", ClientInvoiceNo }
            };

            return response;
        }

        public async Task<VendorSearchResponseEntity> SearchVendorAsync(VendorSearchRequestEntity request)
        {
            var response = new VendorSearchResponseEntity();

            var query = _context.VendorEntity.AsQueryable();

            var VendorName = await _context.VendorEntity
                       .Select(a => a.VendorName)
                       .Distinct()
                       .ToListAsync();

            var VendorType = await query
                       .Select(a => a.VendorType)
                       .Distinct()
                       .ToListAsync();

            var Country = await query
                      .Select(a => a.BillingCountry)
                      .Distinct()
                      .ToListAsync();


            var Status = await query
                       .Select(a => a.Status)
                       .Distinct()
                       .ToListAsync();

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status!.ToLower().Equals(request.Status.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.VendorName))
            {
                query = query.Where(t => t.VendorName!.ToLower().Contains(request.VendorName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(request.VendorType))
            {
                query = query.Where(t => t.VendorType!.ToLower().Contains(request.VendorType.ToLower()));
            }

            if (request.Count == 0)
            {
                response.Vendors = await query.ToListAsync();
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
                response.Vendors = await query.Skip(request.Offset).Take(request.Count).ToListAsync();
                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.Vendors.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count ?
                    null :
                    (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(request.Offset - request.Count)}&count={request.Count}" : null;

            }
            response.Filters = new Dictionary<string, List<string>>
            {
                { "VendorName", VendorName  },
                { "VendorType",VendorType},
                { "Status", Status },
                { "Country", Country },
                
            };

            return response;
        }

        public async Task<PurchaseVendorHistoryResponseEntity> SearchVendorPurchaseAsync(VendorInvoiceReportSearchRequestEntity request)
        {
            var response = new PurchaseVendorHistoryResponseEntity();

            var query = _context.VendorInvoiceTxnEntity
                .Include(x => x.FeeDetails)
                .Include(x => x.VendorEntity)
                .AsQueryable();

            // Apply Filters
            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                query = query.Where(t => t.Status != null && t.Status.ToLower().Contains(request.Status.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(request.Country))
            {
                query = query.Where(t => t.FeeDetails
                    .Any(f => f.country != null
                           && f.country.ToLower().Contains(request.Country.ToLower())));
            }
            var countryList = await query
    .SelectMany(t => t.FeeDetails.Select(f => f.country))
    .Where(c => !string.IsNullOrWhiteSpace(c))
    .Distinct()
    .OrderBy(c => c)
    .ToListAsync();

            // Group at SQL Level
            var groupedQuery = query
                .SelectMany(t => t.FeeDetails.DefaultIfEmpty(), (t, f) => new
                {
                    VendorName = t.VendorEntity!.VendorName,
                    Status = t.Status,
                    Amount = f.amount,
                    Country = f.country
                })
                .GroupBy(x => new { x.VendorName, x.Status })
                .Select(g => new VendorPurchaseAmountReadResponseModel
                {
                    VendorName = g.Key.VendorName,
                    Status = g.Key.Status,
                    TotalAmount = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.VendorName)
                .AsQueryable();

            // Filters (efficient way)
            var Vendors = await groupedQuery.Select(a => a.VendorName)
                                            .Distinct()
                                            .OrderBy(x => x)
                                            .ToListAsync();

            var StatusList = await groupedQuery.Select(a => a.Status)
                                               .Distinct()
                                               .ToListAsync();

            // Paging
            response.Paging.Total = await groupedQuery.CountAsync();

            if (request.Count == 0)
            {
                response.VendorPurchaseReports = await groupedQuery.ToListAsync();
                response.Paging.TotalPages = 0;
                response.Paging.CurrentPage = 0;
                response.Paging.Results = 0;
                response.Paging.NextOffset = null;
                response.Paging.NextPage = null;
                response.Paging.PrevPage = null;
            }
            else
            {
                response.VendorPurchaseReports = await groupedQuery
                    .Skip(request.Offset)
                    .Take(request.Count)
                    .ToListAsync();

                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / request.Count);
                response.Paging.CurrentPage = (request.Offset / request.Count) + 1;
                response.Paging.Results = response.VendorPurchaseReports.Count();
                response.Paging.NextOffset = response.Paging.Total < request.Offset + request.Count
                    ? null
                    : (request.Offset + request.Count).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null
                    ? $"?offset={(response.Paging.CurrentPage * request.Count)}&count={request.Count}"
                    : null;

                response.Paging.PrevPage = response.Paging.CurrentPage > 1
                    ? $"?offset={(request.Offset - request.Count)}&count={request.Count}"
                    : null;
            }

            // Populate Filters
            response.Filters = new Dictionary<string, List<string>>
    {
        { "Vendors", Vendors },
        { "Status", StatusList }
    };

            return response;
        }




    }
}
