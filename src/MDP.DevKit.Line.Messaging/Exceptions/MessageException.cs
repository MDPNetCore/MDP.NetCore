using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class MessageException : Exception
    {
        // Constructors
        public MessageException(string message = null, List<Detail> details = null) : base(message) 
        {
            // Default
            this.Details = details;
        }


        // Properties
        public List<Detail> Details { get; set; } = null;


        // Class
        public class Detail
        {
            // Properties
            public string Message { get; set; } = string.Empty;

            public string Property { get; set; } = string.Empty;
        }


        // Methods
        public override string ToString()
        {
            // MessageBuilder
            var messageBuilder = new StringBuilder();

            // This
            messageBuilder.AppendLine(System.Text.Json.JsonSerializer.Serialize(new
            {
                Message = this.Message,
                Details = this.Details
            }, new JsonSerializerOptions { WriteIndented = false }));

            // Return
            return messageBuilder.ToString();
        }
    }
}
