using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class LeaveEvent : Event
    {
        // Constants
        public const string DefaultEventType = "leave";


        // Constructors
        public LeaveEvent() : base(DefaultEventType) { }


        // Properties

    }
}
