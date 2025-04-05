using Utilities.Constants;

namespace Utilities.Extensions
{
    public static class ErrorDetailExtensions
    {
        
        public static MessageStatusDetailModel ToDetailModel(this ErrorDetail detail, string? elementValue)
        {
            return detail.ToDetailModel(elementValue, Service.ServiceIdentifier);
        }
    }
}
