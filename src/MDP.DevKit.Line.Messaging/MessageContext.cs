using MDP.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    [Service<MessageContext>(singleton: true)]
    public class MessageContext
    {
        // Fields
        private readonly HookService _hookService;


        // Constructors
        public MessageContext
        (
            HookService hookService
        )
        {
            #region Contracts

            ArgumentNullException.ThrowIfNull(hookService);

            #endregion

            // Default
            _hookService = hookService;
        }


        // Properties
        public HookService HookService { get { return _hookService; } }
    }
}
