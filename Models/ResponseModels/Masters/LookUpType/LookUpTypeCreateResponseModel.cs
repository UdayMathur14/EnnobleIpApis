using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters.LookUpType
{
    public class LookUpTypeCreateResponseModel : ResponseMessage
    {
        public int Id { get; set; }

        public LookUpTypeCreateResponseModel() { }

        public LookUpTypeCreateResponseModel(int id)
        {
            Id = id;
        }
    }
}
