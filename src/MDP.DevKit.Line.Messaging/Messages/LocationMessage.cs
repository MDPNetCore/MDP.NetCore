using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public class LocationMessage : Message
    {
        // Constants
        public const string DefaultMessageType = "location";


        // Constructors
        public LocationMessage() : base(DefaultMessageType) { }


        // Properties
        public string Title { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public double Latitude { get; set; } = 0;

        public double Longitude { get; set; } = 0;
    }
}
