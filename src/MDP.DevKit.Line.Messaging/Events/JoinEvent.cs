using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class JoinEvent : Event
    {
        // Constants
        public const string DefaultEventType = "join";


        // Constructors
        public JoinEvent() : base(DefaultEventType) { }


        // Properties
        public string ReplyToken { get; set; } = null;
    }
}
