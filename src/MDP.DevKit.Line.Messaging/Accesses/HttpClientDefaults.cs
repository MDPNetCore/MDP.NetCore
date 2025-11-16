using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public static class HttpClientDefaults
    {
        // Constants
        public static readonly string MessageClientId = $"MDP.DevKit.Line.Messaging.MessageClient_{Guid.NewGuid().ToString()}";

        public static readonly string MessageClientUrl = @"https://api.line.me/v2/bot/";


        public static readonly string ContentClientId = $"MDP.DevKit.Line.Messaging.ContentClient_{Guid.NewGuid().ToString()}";

        public static readonly string ContentClientUrl = @"https://api-data.line.me/v2/bot/";
    }
}
