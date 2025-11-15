using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class TextMessageEvent : MessageEvent
    {
        // Constants
        public const string DefaultMessageType = "text";


        // Constructors
        public TextMessageEvent() : base(DefaultMessageType) { }


        // Properties
        public string Text { get; set; } = string.Empty;
    }
}
