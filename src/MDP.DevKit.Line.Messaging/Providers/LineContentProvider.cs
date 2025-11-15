using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MDP.DevKit.LineMessaging
{
    public class LineContentProvider : ContentProvider
    {
        // Constants
        public const string DefaultContentProviderType = "line";


        // Constructors
        public LineContentProvider() : base(DefaultContentProviderType) { }


        // Properties
        public string MessageId { get; set; } = string.Empty;

        public string OriginalContentUrl { get { return $"https://api-data.line.me/v2/bot/message/{this.MessageId}/content"; } }

        public string PreviewContentUrl { get { return $"https://api-data.line.me/v2/bot/message/{this.MessageId}/content/preview"; } }
    }
}