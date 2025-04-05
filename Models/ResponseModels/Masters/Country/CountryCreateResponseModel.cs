using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters.Country
{
    public class CountryCreateResponseModel : ResponseMessage
    {
        public int Id { get; set; }

        public CountryCreateResponseModel() { }

        public CountryCreateResponseModel(int id)
        {
            Id = id;
        }
    }
}
