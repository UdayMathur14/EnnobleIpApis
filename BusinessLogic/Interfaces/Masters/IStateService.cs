using Models.RequestModels.Masters.State;
using Models.ResponseModels.Masters.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BusinessLogic.Interfaces.Masters
{
    public interface IStateService
    {
        Task<IResponseWrapper<StateSearchResponse>> SearchStateAsync(StateSearchRequestModel requestModel, string? offset, string count);
    }
}
