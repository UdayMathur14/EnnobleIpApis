namespace Models.ResponseModels.Masters.Country
{
    public class CountryReadResponseModel : BaseResponseModel
    {
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? currencyName { get; set; }
        public string? Symbol { get; set; }

    }
}
    