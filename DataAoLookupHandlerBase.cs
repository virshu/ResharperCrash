using System;
using System.Linq;
using GenerateTables.Models;

namespace DataHandler;

public class DataAoLookupHandlerBase
{
    public readonly Func<IQueryable<DataAoLookupResult>, int, IQueryable<DataAoLookupResult>> AddWhereIdentityFunc =
        (q, identity) => q.Where(w => w.RefIdentity == identity);

    public readonly Func<IQueryable<DataAoLookupResult>, DateTime, DateTime, IQueryable<DataAoLookupResult>> AddBetweenDatesFunc =
        (q, dateFrom, dateTo) => q.Where(w => w.RefDateField >= dateFrom && w.RefDateField <= dateTo);

    public readonly Func<IQueryable<DataAoLookupResult>, IQueryable<DataAoLookupResult>> AddWhereNotEmptyFunc =
        q => q.Where(w => w.RefDate != null
            || string.IsNullOrEmpty(w.RefNumber) || string.IsNullOrEmpty(w.RefDetails));

    public readonly Func<IQueryable<DataAoLookupResult>, IQueryable<DataAoLookupResult>> AddOrderByFunc =
        q => q.OrderBy(o => o.RefOrderBy);

    public readonly Func<IQueryable<DataAoLookupResult>, IQueryable<DataAoLookupResult>> AddOrderByDescFunc =
        q => q.OrderByDescending(o => o.RefOrderBy);

    public Func<AAtims, IQueryable<DataAoLookupResult>> InitializeQueryableFunc;
    public Func<AAtims, int, int, int> UpdateEntityFunc;

}

public class DataAoLookupResult
{
    public int RefId { get; set; }
    public string RefOrderBy { get; set; }
    public string RefDate { get; set; }
    public bool RefActive { get; set; }
    public bool RefSeal { get; set; }
    public string RefNumber { get; set; }
    public string RefDetails { get; set; }
    public int? RefIdentity { get; set; }
    public DateTime? RefDateField { get; set; }

    public DataAoLookupResult()
    {
        RefActive = false;
        RefSeal = false;
        RefNumber = string.Empty;
    }
}
