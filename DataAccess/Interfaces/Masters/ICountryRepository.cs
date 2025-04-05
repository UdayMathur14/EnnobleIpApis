using DataAccess.Domain.Masters.Country;

namespace DataAccess.Interfaces.Masters
{
    /// <summary>
    /// <purpose>ICountryRepository to define the method transaction repository.</purpose>
    /// <createdBy>Aman Sinha</createdBy>
    /// <createdOn>20-Mar-2024</createdOn>
    /// <modifiedBy>Milan Jindal</modifiedBy>
    /// <modifiedOn>18-April-2024</modifiedOn>
    /// </summary>
    /// <param name="request"></param>
    /// <param name=""></param>
    /// <param name=""></param>
    /// <returns></returns>
    public interface ICountryRepository : IRepository<CountryEntity>
    {
        Task<CountrySearchResponseEntity> SearchCountryAsync(CountrySearchRequestEntity request);
        Task<CountryEntity> FindByTxnTypeCodeAsync(string txnTypeCode);
    }
}
