using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Utilities.Implementation;

namespace Utilities
{
    public interface IResponseWrapper<out TResponse> : IResponseWrappers where TResponse : IResponseMessage
    {
        TResponse? Response { get; }
    }

   

   

    public class MessageStatusModel
    {
        public string? ResponseCode { get; set; }

        public string? Description { get; set; }

        public string? MessageSource { get; set; }

        public string? MethodName { get; set; }

        public List<MessageStatusDetailModel> Details { get; set; } = new List<MessageStatusDetailModel>();

    }
    public class MessageStatusDetailModel
    {
        public string? Code { get; set; }

        public Category? Category { get; set; }

        public string? Description { get; set; }

        public string? Element { get; set; }

        public string? ElementValue { get; set; }

        public string? Location { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter<Category>))]
    public enum Category
    {
        Error,
        Fault,
        Warning,
        Overridden
    }
    public class ErrorDetail
    {
        public string Code { get; }

        public Category Category { get; }

        public string Description { get; }

        public string Element { get; }

        public ErrorDetail(string code, Category category, string description, string element)
        {
            Code = code;
            Category = category;
            Description = description;
            Element = element;
        }

        public MessageStatusDetailModel ToDetailModel(string? elementValue, string? location)
        {
            return new MessageStatusDetailModel
            {
                Code = Code,
                Category = Category,
                Description = Description,
                Element = Element,
                ElementValue = elementValue,
                Location = location
            };
        }
    }
}
