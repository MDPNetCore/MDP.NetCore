using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using MDP.Registration;
using MDP.DevKit.Line.Messaging;
using MDP.Network.Http;

namespace MDP.DevKit.Line.Messaging
{
    public class MessageContextFactory: ServiceFactory<IServiceCollection, MessageContextFactory.Setting>
    {
        // Constructors
        public MessageContextFactory() : base("MDP.DevKit.Line.Messaging", null, false) { }


        // Methods
        public override void ConfigureService(IServiceCollection serviceCollection, Setting setting)
        {
            #region Contracts

            if (serviceCollection == null) throw new ArgumentException($"{nameof(serviceCollection)}=null");
            if (setting == null) throw new ArgumentException($"{nameof(setting)}=null");

            #endregion

            // Domain
            serviceCollection.TryAddSingleton<MessageContext>();

            // Accesses
            serviceCollection.TryAddTransient<EventService>(serviceProvider => { return new EventServiceProvider(setting.ChannelSecret); });
            serviceCollection.TryAddTransient<MessageService, MessageServiceProvider>();
            
            // HttpClient
            serviceCollection.AddHttpClient(
                name: HttpClientDefaults.MessageClientId,
                baseAddress: HttpClientDefaults.MessageClientUrl,
                headers: new Dictionary<string, string>() { { "Authorization", $"Bearer {setting.ChannelAccessToken}" } }
            );
            serviceCollection.AddHttpClient(
                name: HttpClientDefaults.ContentClientId,
                baseAddress: HttpClientDefaults.ContentClientUrl,
                headers: new Dictionary<string, string>() { { "Authorization", $"Bearer {setting.ChannelAccessToken}" } }
            );
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
