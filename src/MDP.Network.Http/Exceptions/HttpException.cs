using System.Text;
using System.Text.Json;

namespace System.Net.Http
{
    public class HttpException<TErrorModel> : Exception where TErrorModel : class
    {
        // Constants
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };


        // Constructors
        public HttpException(HttpStatusCode statusCode, string message, TErrorModel model) : base(message)
        {
            // Default
            this.StatusCode = statusCode;
            this.ErrorModel = model;
        }


        // Properties
        public HttpStatusCode StatusCode { get; }

        public TErrorModel ErrorModel { get; }


        // Methods
        public override string ToString()
        {
            // MessageBuilder
            var messageBuilder = new StringBuilder();

            // Base
            messageBuilder.AppendLine(base.ToString() ?? string.Empty);

            // ErrorModel
            messageBuilder.AppendLine(System.Text.Json.JsonSerializer.Serialize(this.ErrorModel, _jsonSerializerOptions));

            // Return
            return messageBuilder.ToString();
        }
    }
}
