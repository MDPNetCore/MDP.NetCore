using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using MDP.Registration;

namespace MDP.DevKit.LineMessaging.Hosting
{
    public class MessageContextFactory: ServiceFactory<IServiceCollection, MessageContextFactory.Setting>
    {
        // Constructors
        public MessageContextFactory() : base("MDP.DevKit.Line.Messaging") { }


        // Methods
        public override void ConfigureService(IServiceCollection serviceCollection, Setting setting)
        {
            #region Contracts

            if (serviceCollection == null) throw new ArgumentException($"{nameof(serviceCollection)}=null");
            if (setting == null) throw new ArgumentException($"{nameof(setting)}=null");

            #endregion

            // Domain
            serviceCollection.TryAddSingleton<MessageContextFactory>();

            // Accesses
            serviceCollection.TryAddTransient<HookService>(serviceProvider => { return new HookServiceProvider(setting.ChannelSecret); });
        }


        // Class
        public class Setting
        {
            // Properties
            public string ChannelSecret { get; set; }

            public string ChannelAccessToken { get; set; }
        }
    }
}
