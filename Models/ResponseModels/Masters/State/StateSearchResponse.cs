using Models.ResponseModels.BaseResponseSetup;
using Models.ResponseModels.Masters.State;

namespace Models.ResponseModels.Masters.State
{
    public class StateSearchResponse : SearchResponseBase<StateReadResponseModel>
    {
        public List<StateReadResponseModel> States => base.Results;
    }
}
