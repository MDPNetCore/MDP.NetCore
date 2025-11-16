using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public class StickerMessage : Message
    {
        // Constants
        public const string DefaultMessageType = "sticker";


        // Constructors
        public StickerMessage() : base(DefaultMessageType) { }


        // Properties
        public int PackageId { get; set; } = 1;

        public int StickerId { get; set; } = 1;
    }
}
