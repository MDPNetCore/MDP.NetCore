using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public class FlexMessage : Message
    {
        // Constants
        public const string DefaultMessageType = "flex";


        // Constructors
        public FlexMessage() : base(DefaultMessageType) { }


        // Properties
        public string AlternativeText { get; set; } = string.Empty;

        public string Contents { get; set; } = string.Empty;
    }
}
