using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    internal class ErrorModel
    {
        // Properties
        public string? message { get; set; } = string.Empty;

        public detail[]? details { get; set; } = null;


        // Class
        public class detail
        {
            // Properties
            public string? message { get; set; } = string.Empty;

            public string? property { get; set; } = string.Empty;
        }


        // Methods
        public MessageException ToException()
        {
            // Create
            var exception = new MessageException
            (
                message: this.message,
                details: this.details?.Select(o => new MessageException.Detail()
                {
                    Message = o.message,
                    Property = o.property,
                }).ToList()
            );

            // Return
            return exception;
        }
    }
}
