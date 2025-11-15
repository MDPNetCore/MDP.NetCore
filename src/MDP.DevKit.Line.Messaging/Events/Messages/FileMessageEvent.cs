using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class FileMessageEvent : MessageEvent
    {
        // Constants
        public const string DefaultMessageType = "file";


        // Constructors
        public FileMessageEvent() : base(DefaultMessageType) { }


        // Properties
        public ContentProvider ContentProvider { get; set; } = null;

        public string FileName { get; set; } = string.Empty;

        public int FileSize { get; set; } = default(int);
    }
}
