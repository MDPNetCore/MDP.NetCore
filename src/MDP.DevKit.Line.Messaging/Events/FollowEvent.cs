using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class FollowEvent : Event
    {
        // Constants
        public const string DefaultEventType = "follow";


        // Constructors
        public FollowEvent() : base(DefaultEventType) { }


        // Properties
        public string ReplyToken { get; set; } = null;
    }
}
