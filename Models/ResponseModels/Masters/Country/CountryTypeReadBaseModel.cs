namespace Models.ResponseModels.Masters.Country
{
    public class CountryReadBaseModel
    {
        public int Id { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? Status { get; set; }
        public CommonNestedResponseModel? GLSubCategory { get; set; }
    }
}
