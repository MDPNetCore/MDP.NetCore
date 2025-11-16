using MDP.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public class MessageContext
    {
        // Fields
        private readonly EventService _eventService;

        private readonly MessageService _messageService;


        // Constructors
        public MessageContext
        (
            EventService eventService,
            MessageService messageService
        )
        {
            #region Contracts

            ArgumentNullException.ThrowIfNull(eventService);
            ArgumentNullException.ThrowIfNull(messageService);

            #endregion

            // Default
            _eventService = eventService;
            _messageService = messageService;
        }


        // Properties
        public EventService EventService { get { return _eventService; } }

        public MessageService MessageService { get { return _messageService; } }


        // Methods
        public List<Event> HandleEvent(string content, string signature)
        {
            #region Contracts

            if (string.IsNullOrEmpty(content) == true) throw new ArgumentException($"{nameof(content)}=null");
            if (string.IsNullOrEmpty(signature) == true) throw new ArgumentException($"{nameof(signature)}=null");

            #endregion

            // EventService
            return this.EventService.Handle(content, signature);
        }
    }
}
