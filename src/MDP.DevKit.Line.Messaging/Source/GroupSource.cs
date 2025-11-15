using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class GroupSource : Source
    {
        // Constants
        public const string DefaultSourceType = "group";


        // Constructors
        public GroupSource() : base(DefaultSourceType) { }


        // Properties
        public string GroupId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
    }
}
