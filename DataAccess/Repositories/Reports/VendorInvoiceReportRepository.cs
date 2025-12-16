using DataAccess.Domain.Masters.Vendor;
using DataAccess.Domain.Masters.VendorInvoiceReport;
using DataAccess.Domain.Masters.VendorInvoiceTxn;
using DataAccess.Domain.Reports.VendorInvoiceReport;
using DataAccess.Interfaces.VendorInvoiceReport;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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

            // Base query with eager loading
            var query = _context.VendorInvoiceTxnEntity
                .Include(x => x.VendorEntity)
                .Include(x => x.PaymentInvoiceDetails)
                .OrderByDescending(x => x.InvoiceDate)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(request.Status))
                query = query.Where(t => t.Status!.ToLower().Equals(request.Status.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.ApplicationNumber))
                query = query.Where(t => t.ApplicationNumber!.ToLower().Contains(request.ApplicationNumber.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.ClientInvoiceNumber))
                query = query.Where(t => t.ClientInvoiceNo!.ToLower().Contains(request.ClientInvoiceNumber.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.VendorName))
                query = query.Where(t => t.VendorEntity.VendorName!.ToLower().Contains(request.VendorName.ToLower()));

            // 🔹 Calculate TotalPaidAmount and RemainingBalance
            var calculatedQuery = query
                .Select(invoice => new VendorInvoiceTxnEntity
                {
                    Id = invoice.Id,
                    TotalAmount = invoice.TotalAmount,
                    InvoiceDate = invoice.InvoiceDate,
                    ClientInvoiceNo = invoice.ClientInvoiceNo,
                    DueDateAsPerInvoice = invoice.DueDateAsPerInvoice,
                    DueDateAsPerContract = invoice.DueDateAsPerContract,
                    VendorEntity = invoice.VendorEntity,
                    TotalPaidAmount = invoice.PaymentInvoiceDetails.Sum(p => p.paymentAmount) ?? 0,
                    RemainingBalance = invoice.TotalAmount - (invoice.PaymentInvoiceDetails.Sum(p => p.paymentAmount) ?? 0)
                });

            // 🔹 Filter by due date if provided
            if (request.DueDate.HasValue)
            {
                var selectedDueDate = request.DueDate.Value.Date;
                calculatedQuery = calculatedQuery
                    .Where(x => x.RemainingBalance > 0 &&
                                (x.DueDateAsPerInvoice <= selectedDueDate || x.DueDateAsPerContract <= selectedDueDate));
            }
            else
            {
                // All unpaid invoices if no due date selected
                calculatedQuery = calculatedQuery.Where(x => x.RemainingBalance > 0);
            }

            // Total count for pagination
            response.Paging.Total = await calculatedQuery.AsNoTracking().CountAsync();

            // Pagination
            int offsetValue = request.Offset;
            int countValue = request.Count;

            if (countValue == 0)
            {
                response.VendorInvoiceTxn = await calculatedQuery.ToListAsync();
                response.Paging.TotalPages = 0;
                response.Paging.CurrentPage = 0;
                response.Paging.Results = response.VendorInvoiceTxn.Count();
                response.Paging.NextOffset = null;
                response.Paging.NextPage = null;
                response.Paging.PrevPage = null;
            }
            else
            {
                response.VendorInvoiceTxn = await calculatedQuery
                    .Skip(offsetValue)
                    .Take(countValue)
                    .ToListAsync();

                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / countValue);
                response.Paging.CurrentPage = (offsetValue / countValue) + 1;
                response.Paging.Results = response.VendorInvoiceTxn.Count();
                response.Paging.NextOffset = response.Paging.Total < offsetValue + countValue ? null : (offsetValue + countValue).ToString();
                response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * countValue)}&count={countValue}" : null;
                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(offsetValue - countValue)}&count={countValue}" : null;
            }

            // Filters for UI dropdowns
            response.Filters = new Dictionary<string, List<string>>
    {
        { "Status", await _context.VendorInvoiceTxnEntity.Select(a => a.Status).Distinct().ToListAsync() },
        { "ApplicationNumber", await _context.VendorInvoiceTxnEntity.Select(a => a.ApplicationNumber).Distinct().ToListAsync() },
        { "ClientInvoiceNo", await _context.VendorInvoiceTxnEntity.Select(a => a.ClientInvoiceNo).Distinct().ToListAsync() },
        { "Vendors", await _context.VendorInvoiceTxnEntity
                     .Where(a => a.VendorEntity != null && a.VendorEntity.VendorName != null)
                     .Select(a => a.VendorEntity.VendorName)
                     .Distinct()
                     .OrderBy(x => x)
                     .ToListAsync()
        }
    };

            return response;
        }

        public async Task<PurchaseVendorHistoryResponseEntity> SearchVendorInvoiceTxnAsync3(VendorInvoiceTxnSearchRequestEntity request)
        {
            var response = new PurchaseVendorHistoryResponseEntity();

            // Base query
            var query = _context.VendorInvoiceTxnEntity
                .Include(x => x.VendorEntity)
                .Include(x => x.PaymentInvoiceDetails)
                .AsQueryable();

            // Filters (same as earlier)
            if (!string.IsNullOrWhiteSpace(request.Status))
                query = query.Where(t => t.Status!.ToLower().Equals(request.Status.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.ApplicationNumber))
                query = query.Where(t => t.ApplicationNumber!.ToLower().Contains(request.ApplicationNumber.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.ClientInvoiceNumber))
                query = query.Where(t => t.ClientInvoiceNo!.ToLower().Contains(request.ClientInvoiceNumber.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.VendorName))
                query = query.Where(t => t.VendorEntity.VendorName!.ToLower().Contains(request.VendorName.ToLower()));

            // Calculate RemainingBalance per invoice
            var calculatedQuery = query.Select(invoice => new
            {
                VendorId = invoice.VendorID,
                VendorName = invoice.VendorEntity.VendorName,
                RemainingBalance = invoice.TotalAmount - (invoice.PaymentInvoiceDetails.Sum(p => p.paymentAmount) ?? 0)
            })
            .Where(x => x.RemainingBalance > 0); // All outstanding

            // Grouping by vendor with sum
            var groupedQuery = calculatedQuery
                .GroupBy(x => new { x.VendorId, x.VendorName })
                .Select(g => new VendorPurchaseAmountReadResponseModel
                {
                    VendorId = g.Key.VendorId,
                    VendorName = g.Key.VendorName,
                    TotalAmount = g.Sum(x => x.RemainingBalance)
                })
                .OrderBy(x => x.VendorName)
                .AsQueryable();

            // Pagination Counts
            response.Paging.Total = await groupedQuery.CountAsync();
            int offsetValue = request.Offset;
            int countValue = request.Count;

            if (countValue == 0)
            {
                response.VendorPurchaseReports = await groupedQuery.ToListAsync(); // convert to list of object
                response.Paging.TotalPages = 0;
                response.Paging.CurrentPage = 0;
                response.Paging.Results = response.VendorPurchaseReports.Count();
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


                response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / countValue);
                response.Paging.CurrentPage = (offsetValue / countValue) + 1;
                response.Paging.Results = response.VendorPurchaseReports.Count();
                response.Paging.NextOffset = response.Paging.Total < offsetValue + countValue
                    ? null
                    : (offsetValue + countValue).ToString();

                response.Paging.NextPage = response.Paging.NextOffset != null ?
                    $"?offset={(response.Paging.CurrentPage * countValue)}&count={countValue}" : null;

                response.Paging.PrevPage = response.Paging.CurrentPage > 1 ?
                    $"?offset={(offsetValue - countValue)}&count={countValue}" : null;
            }

            // Filters (same as existing)
            response.Filters = new Dictionary<string, List<string>>
    {
        { "Status", await _context.VendorInvoiceTxnEntity.Select(a => a.Status).Distinct().ToListAsync() },
        { "ApplicationNumber", await _context.VendorInvoiceTxnEntity.Select(a => a.ApplicationNumber).Distinct().ToListAsync() },
        { "ClientInvoiceNo", await _context.VendorInvoiceTxnEntity.Select(a => a.ClientInvoiceNo).Distinct().ToListAsync() },
        { "Vendors", await _context.VendorInvoiceTxnEntity.Where(a => a.VendorEntity != null && a.VendorEntity.VendorName != null)
                     .Select(a => a.VendorEntity.VendorName).Distinct().OrderBy(x => x).ToListAsync() }
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

    //    public async Task<VendorInvoiceTxnSearchResponseEntity> GetTotalOutstandingAsync(VendorInvoiceTxnSearchRequestEntity request)
    //    {
    //        var response = new VendorInvoiceTxnSearchResponseEntity();

    //        // Base query with eager loading
    //        var query = _context.VendorInvoiceTxnEntity
    //            .Include(x => x.VendorEntity)
    //            .Include(x => x.PaymentInvoiceDetails)
    //            .OrderByDescending(x => x.InvoiceDate)
    //            .AsQueryable();

    //        // Apply filters (optional: Vendor, Status, ClientInvoiceNo, ApplicationNumber)
    //        if (!string.IsNullOrWhiteSpace(request.Status))
    //            query = query.Where(t => t.Status!.ToLower().Equals(request.Status.ToLower()));

    //        if (!string.IsNullOrWhiteSpace(request.ApplicationNumber))
    //            query = query.Where(t => t.ApplicationNumber!.ToLower().Contains(request.ApplicationNumber.ToLower()));

    //        if (!string.IsNullOrWhiteSpace(request.ClientInvoiceNumber))
    //            query = query.Where(t => t.ClientInvoiceNo!.ToLower().Contains(request.ClientInvoiceNumber.ToLower()));

    //        if (!string.IsNullOrWhiteSpace(request.VendorName))
    //            query = query.Where(t => t.VendorEntity.VendorName!.ToLower().Contains(request.VendorName.ToLower()));

    //        // 🔹 Calculate TotalPaidAmount and RemainingBalance
    //        var calculatedQuery = query
    //            .Select(invoice => new VendorInvoiceTxnEntity
    //            {
    //                Id = invoice.Id,
    //                TotalAmount = invoice.TotalAmount,
    //                InvoiceDate = invoice.InvoiceDate,
    //                ClientInvoiceNo = invoice.ClientInvoiceNo,
    //                DueDateAsPerInvoice = invoice.DueDateAsPerInvoice,
    //                DueDateAsPerContract = invoice.DueDateAsPerContract,
    //                VendorEntity = invoice.VendorEntity,
    //                TotalPaidAmount = invoice.PaymentInvoiceDetails.Sum(p => p.paymentAmount) ?? 0,
    //                RemainingBalance = invoice.TotalAmount - (invoice.PaymentInvoiceDetails.Sum(p => p.paymentAmount) ?? 0)
    //            });

    //        // 🔹 Only unpaid invoices (outstanding) — due or not
    //        var outstandingQuery = calculatedQuery.Where(x => x.RemainingBalance > 0);

    //        // Total count for pagination
    //        response.Paging.Total = await outstandingQuery.AsNoTracking().CountAsync();

    //        // Pagination
    //        int offsetValue = request.Offset;
    //        int countValue = request.Count;

    //        if (countValue == 0)
    //        {
    //            response.VendorInvoiceTxn = await outstandingQuery.ToListAsync();
    //            response.Paging.TotalPages = 0;
    //            response.Paging.CurrentPage = 0;
    //            response.Paging.Results = response.VendorInvoiceTxn.Count();
    //            response.Paging.NextOffset = null;
    //            response.Paging.NextPage = null;
    //            response.Paging.PrevPage = null;
    //        }
    //        else
    //        {
    //            response.VendorInvoiceTxn = await outstandingQuery
    //                .Skip(offsetValue)
    //                .Take(countValue)
    //                .ToListAsync();

    //            response.Paging.TotalPages = (int)Math.Ceiling((double)response.Paging.Total / countValue);
    //            response.Paging.CurrentPage = (offsetValue / countValue) + 1;
    //            response.Paging.Results = response.VendorInvoiceTxn.Count();
    //            response.Paging.NextOffset = response.Paging.Total < offsetValue + countValue ? null : (offsetValue + countValue).ToString();
    //            response.Paging.NextPage = response.Paging.NextOffset != null ? $"?offset={(response.Paging.CurrentPage * countValue)}&count={countValue}" : null;
    //            response.Paging.PrevPage = response.Paging.CurrentPage > 1 ? $"?offset={(offsetValue - countValue)}&count={countValue}" : null;
    //        }

    //        // Filters for UI dropdowns
    //        response.Filters = new Dictionary<string, List<string>>
    //{
    //    { "Status", await _context.VendorInvoiceTxnEntity.Select(a => a.Status).Distinct().ToListAsync() },
    //    { "ApplicationNumber", await _context.VendorInvoiceTxnEntity.Select(a => a.ApplicationNumber).Distinct().ToListAsync() },
    //    { "ClientInvoiceNo", await _context.VendorInvoiceTxnEntity.Select(a => a.ClientInvoiceNo).Distinct().ToListAsync() },
    //    { "Vendors", await _context.VendorInvoiceTxnEntity
    //                 .Where(a => a.VendorEntity != null && a.VendorEntity.VendorName != null)
    //                 .Select(a => a.VendorEntity.VendorName)
    //                 .Distinct()
    //                 .OrderBy(x => x)
    //                 .ToListAsync()
    //    }
    //};

    //        return response;
    //    }





    }
}
