using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters.LookUp
{
    public class LookUpCreateResponseModel : ResponseMessage
    {
        public int Id { get; set; }

        public LookUpCreateResponseModel() { }
    
        public LookUpCreateResponseModel(int id)
        {
            Id = id;
        }
    }
}
