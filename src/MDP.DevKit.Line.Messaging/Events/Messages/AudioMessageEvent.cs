using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class AudioMessageEvent : MessageEvent
    {
        // Constants
        public const string DefaultMessageType = "audio";


        // Constructors
        public AudioMessageEvent() : base(DefaultMessageType) { }


        // Properties
        public ContentProvider ContentProvider { get; set; } = null;

        public int Duration { get; set; } = default(int);
    }
}
