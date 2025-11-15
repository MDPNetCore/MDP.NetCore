using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public abstract class MessageEvent : Event
    {
        // Constants
        public const string DefaultEventType = "message";


        // Constructors
        protected MessageEvent(string messageType) : base(DefaultEventType)
        {
            #region Contracts

            if (string.IsNullOrEmpty(messageType) == true) throw new ArgumentException($"{nameof(messageType)}=null");

            #endregion

            // Default
            this.MessageType = messageType;
        }


        // Properties
        public string MessageType { get; } = string.Empty;

        public string MessageId { get; set; } = string.Empty;

        public string ReplyToken { get; set; } = null;
    }
}
