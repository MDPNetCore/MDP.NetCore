using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class ImageMessageEvent : MessageEvent
    {
        // Constants
        public const string DefaultMessageType = "image";


        // Constructors
        public ImageMessageEvent() : base(DefaultMessageType) { }


        // Properties
        public ContentProvider ContentProvider { get; set; } = null;
    }
}
