using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public class ImageMessage : Message
    {
        // Constants
        public const string DefaultMessageType = "image";


        // Constructors
        public ImageMessage() : base(DefaultMessageType) { }


        // Properties
        public string OriginalContentUrl { get; set; } = string.Empty;

        public string PreviewImageUrl { get; set; } = string.Empty;
    }
}
