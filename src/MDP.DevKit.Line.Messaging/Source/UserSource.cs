using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public class UserSource : Source
    {
        // Constants
        public const string DefaultSourceType = "user";


        // Constructors
        public UserSource() : base(DefaultSourceType) { }


        // Properties
        public string UserId { get; set; } = string.Empty;
    }
}
