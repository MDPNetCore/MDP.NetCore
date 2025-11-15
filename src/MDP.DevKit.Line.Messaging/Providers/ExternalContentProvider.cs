using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class ExternalContentProvider : ContentProvider
    {
        // Constants
        public const string DefaultContentProviderType = "external";


        // Constructors
        public ExternalContentProvider() : base(DefaultContentProviderType) { }


        // Properties
        public string OriginalContentUrl { get; set; } = string.Empty;

        public string PreviewContentUrl { get; set; } = string.Empty;
    }
}
