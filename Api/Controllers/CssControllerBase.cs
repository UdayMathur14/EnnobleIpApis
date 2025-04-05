using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Utilities;
using Utilities.Constants;

namespace Api.Controllers
{
    public abstract class CssControllerBase : ControllerBase
    {
        [NonAction]
        public virtual ActionResult HandleResponse(IResponseWrappers responseWrappers, int statusCode = StatusCodes.Status200OK)
        {
            if (responseWrappers.HasMessages)
            {
                if (responseWrappers.HasErrors)
                {
                    statusCode = StatusCodes.Status400BadRequest;

                    if (responseWrappers.Messages.Exists(m => m.Code == Codes.EntityNotFound))
                    {
                        statusCode = StatusCodes.Status404NotFound;
                    }

                    return this.StatusCode(
                    statusCode,
                    responseWrappers.ToMessageStatus(
                        ReasonPhrases.GetReasonPhrase(statusCode),
                        statusCode.ToString()));
                }
            }

            var response = responseWrappers.ToResponse(
                ReasonPhrases.GetReasonPhrase(statusCode),
                statusCode.ToString());

            return this.StatusCode(statusCode, response);
        }
    }
}
