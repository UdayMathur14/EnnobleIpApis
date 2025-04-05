using System.Runtime.Serialization;
using Utilities;
using Utilities.Constants;

namespace BusinessLogic.Rules.Exceptions
{
    [Serializable]
    public class RuleException : Exception
    {
        public RuleException(
            string? message,
            string? element, 
            string? value,
            string code = Codes.DataValidationError,
            Category category = Category.Error) 
            : base(message ?? string.Empty)
        {
            this.Element = element ?? string.Empty;
            this.ElementValue = value ?? string.Empty;
            this.Code = code ?? string.Empty;
            this.Category = category;
        }

        protected RuleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Element = string.Empty;
            this.ElementValue = string.Empty;
            this.Code = Codes.DataValidationError;
            this.Category = Category.Error;
        }

        public string Element { get; private set; }
        public string ElementValue { get; private set; }
        public string Code { get; private set; }
        public Category Category { get; private set; }
    }
}
