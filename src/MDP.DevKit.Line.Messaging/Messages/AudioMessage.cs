using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public class AudioMessage : Message
    {
        // Constants
        public const string DefaultMessageType = "audio";


        // Constructors
        public AudioMessage() : base(DefaultMessageType) { }


        // Properties
        public string OriginalContentUrl { get; set; } = string.Empty;

        public int Duration { get; set; } = 0; // Milliseconds
    }
}
