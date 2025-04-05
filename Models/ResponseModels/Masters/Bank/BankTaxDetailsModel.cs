namespace Models.ResponseModels.Masters.Bank
{
    public class BankTaxDetailsModel
    {
        public string TaxationType { get; set; }
        public string TaxCodes { get; set; }
        public string TdsCodes { get; set; }
        public int? CGSTPercentage { get; set; }
        public int? SGSTPercentage { get; set; }
        public int? IGSTPercentage { get; set; }
    }
}
