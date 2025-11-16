using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public class LineContentProvider : ContentProvider
    {
        // Constants
        public const string DefaultContentProviderType = "line";


        // Constructors
        public LineContentProvider() : base(DefaultContentProviderType) { }


        // Properties
        public string MessageId { get; set; } = string.Empty;
    }
}
