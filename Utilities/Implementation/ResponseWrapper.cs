namespace Utilities.Implementation
{
    public class ResponseWrapper<TResponse> : IResponseWrapper<TResponse>
        where TResponse : IResponseMessage, new()
    {
        public List<MessageStatusDetailModel> Messages { get; private set; } = new List<MessageStatusDetailModel>();

        public TResponse Response { get; set; } = new TResponse();

        public bool HasMessages
        {
            get
            {
                return this.Messages.Count != 0;
            }
        }

        public bool HasErrors
        {
            get
            {
                return this.Messages.Exists(m => m.Category == Category.Error || m.Category == Category.Fault);
            }
        }

        public MessageStatusModel ToMessageStatus(string description, string responseCode)
        {
            var messageStatus = new MessageStatusModel
            {
                Description = description,
                ResponseCode = responseCode,
                //MessageSource = Service.ProductId
            };

            messageStatus.Details.AddRange(this.Messages);

            return messageStatus;
        }

        public object ToResponse(string description, string responseCode)
        {
            if(this.Response == null)
            {
                throw new InvalidOperationException($"{nameof(this.Response)} should not be null when calling {nameof(this.ToResponse)}");
            }

            this.Response.MessageStatus = this.ToMessageStatus(description, responseCode);

            if(this.Response.MessageStatus.Details.Count == 0)
            {
                this.Response.MessageStatus = null;
            }

            return this.Response;
        }
    }
}
