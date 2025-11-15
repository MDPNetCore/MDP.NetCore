using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public abstract class Event
    {
        // Constructors
        protected Event(string eventType)
        {
            #region Contracts

            if (string.IsNullOrEmpty(eventType) == true) throw new ArgumentException($"{nameof(eventType)}=null");

            #endregion

            // Default
            this.EventType = eventType;
        }


        // Properties
        public string EventType { get; } = string.Empty;

        public string EventId { get; set; } = string.Empty;

        public Source Source { get; set; } = null;

        public bool IsRedelivery { get; set; } = false;

        public long Timestamp { get; set; } = default(long);

        public ChannelMode Mode { get; set; } = ChannelMode.Active;
    }
}