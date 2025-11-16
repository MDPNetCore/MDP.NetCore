using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public class TextMessage : Message
    {
        // Constants
        public const string DefaultMessageType = "text";


        // Constructors
        public TextMessage() : base(DefaultMessageType) { }


        // Properties
        public string Text { get; set; } = string.Empty;
    }
}
