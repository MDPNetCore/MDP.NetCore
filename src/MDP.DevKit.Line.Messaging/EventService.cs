using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public interface EventService
    {
        // Methods
        List<Event> Handle(string content, string signature);
    }
}
