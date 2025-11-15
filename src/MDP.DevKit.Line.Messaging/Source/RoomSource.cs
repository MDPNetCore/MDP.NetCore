using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class RoomSource : Source
    {
        // Constants
        public const string DefaultSourceType = "room";


        // Constructors
        public RoomSource() : base(DefaultSourceType) { }


        // Properties
        public string RoomId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
    }
}
