using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class UnfollowEvent : Event
    {
        // Constants
        public const string DefaultEventType = "unfollow";


        // Constructors
        public UnfollowEvent() : base(DefaultEventType) { }


        // Properties

    }
}
