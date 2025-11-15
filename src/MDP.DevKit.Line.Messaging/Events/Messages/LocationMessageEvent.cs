using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class LocationMessageEvent : MessageEvent
    {
        // Constants
        public const string DefaultMessageType = "location";


        // Constructors
        public LocationMessageEvent() : base(DefaultMessageType) { }


        // Properties
        public string Title { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public double Latitude { get; set; } = 0;

        public double Longitude { get; set; } = 0;
    }
}
