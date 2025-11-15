using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class StickerMessageEvent : MessageEvent
    {
        // Constants
        public const string DefaultMessageType = "sticker";


        // Constructors
        public StickerMessageEvent() : base(DefaultMessageType) { }


        // Properties
        public string StickerResourceType { get; set; }

        public string PackageId { get; set; }

        public string StickerId { get; set; } 
    }
}
