using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class VideoMessageEvent : MessageEvent
    {
        // Constants
        public const string DefaultMessageType = "video";


        // Constructors
        public VideoMessageEvent() : base(DefaultMessageType) { }


        // Properties
        public ContentProvider ContentProvider { get; set; } = null;

        public int Duration { get; set; } = default(int);
    }
}
