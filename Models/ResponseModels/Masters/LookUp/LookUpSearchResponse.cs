using Models.ResponseModels.BaseResponseSetup;

namespace Models.ResponseModels.Masters
{ 
    public class LookUpSearchResponse : SearchResponseBase<LookUpReadResponseModel>
    {
        public new List<LookUpReadResponseModel> LookUps 
        { 
            get => base.Results; 
            set => base.Results = value; 
        }
    }
}
