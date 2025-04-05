using Models.RequestModels;

namespace DataAccess.Domain.Masters.Country
{
    public class CountryRequestModel : BaseRequestModel
    {
        public int? ICountryId { get; set; }
        public int? GlSubCategoryId { get; set; }
        public string? Status { get; set; }
    }
}
