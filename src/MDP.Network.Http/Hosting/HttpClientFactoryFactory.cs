using MDP.Registration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Net.Http;

namespace MDP.Network.Http
{
    public class HttpClientFactoryFactory: ServiceFactory<IServiceCollection, HttpClientFactoryFactory.SettingDictionary>
    {
        // Constructors
        public HttpClientFactoryFactory() : base("MDP.Network.Http", "HttpClientFactory", false) { }


        // Methods
        public override void ConfigureService(IServiceCollection serviceCollection, SettingDictionary settingDictionary)
        {
            #region Contracts

            if (serviceCollection == null) throw new ArgumentException($"{nameof(serviceCollection)}=null");
            if (settingDictionary == null) throw new ArgumentException($"{nameof(settingDictionary)}=null");

            #endregion

            // HttpClientFactory
            serviceCollection.AddHttpClient();

            // HttpClientBuilder
            foreach (var setting in settingDictionary)
            {
                // Require
                if (string.IsNullOrEmpty(setting.Key) == true) throw new InvalidOperationException($"{nameof(setting.Key)}=null");
                if (setting.Value == null) throw new InvalidOperationException($"{nameof(setting.Value)}=null");
                if (setting.Value.Handlers == null) setting.Value.Handlers = new List<string>();
                if (setting.Value.Headers == null) setting.Value.Headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                // HttpClientBuilder
                var httpClientBuilder = serviceCollection.AddHttpClient(setting.Key, httpClient =>
                {
                    // BaseAddress
                    var baseAddress = setting.Value.BaseAddress;
                    if (string.IsNullOrEmpty(baseAddress) == false)
                    {
                        // EndsWith
                        if (baseAddress.EndsWith(@"/") == false) baseAddress += @"/";

                        // Set
                        httpClient.BaseAddress = new Uri(baseAddress);
                    }

                    // Headers
                    foreach (var header in setting.Value.Headers)
                    {
                        // Add
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                });

                // System.Net.Http.HttpClientHandler
                httpClientBuilder = httpClientBuilder.ConfigurePrimaryHttpMessageHandler(serviceProvider =>
                {
                    // Create
                    var httpClientHandler = new System.Net.Http.SocketsHttpHandler();
                    {
                        // UseCookies
                        httpClientHandler.UseCookies = setting.Value.UseCookies;

                        // IgnoreCertificates
                        if (setting.Value.IgnoreServerCertificate == true)
                        {
                            httpClientHandler.SslOptions.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return false; };
                        }
                    }

                    // Return
                    return httpClientHandler;
                });

                // MDP.Network.Http.HttpClientHandler
                httpClientBuilder = httpClientBuilder.ConfigureAdditionalHttpMessageHandlers((httpMessageHandlerList, serviceProvider) =>
                {
                    if (setting.Value.Handlers.Count <= 0)
                    {
                        // Typed
                        {
                            // Resolve
                            var httpClientHandlerList = serviceProvider.GetServices<MDP.Network.Http.HttpClientHandler>();
                            if (httpClientHandlerList == null) throw new InvalidOperationException($"{nameof(httpClientHandlerList)}=null");

                            // Add
                            foreach (var httpClientHandler in httpClientHandlerList)
                            {
                                httpMessageHandlerList.Add(httpClientHandler);
                            }
                        }
                    }
                    else
                    {
                        // Named   
                        foreach (var handler in setting.Value.Handlers)
                        {
                            // Resolve
                            var httpClientHandler = serviceProvider.ResolveNamed<MDP.Network.Http.HttpClientHandler>(handler);
                            if (httpClientHandler == null) throw new InvalidOperationException($"{nameof(httpClientHandler)}=null");

                            // Add
                            httpMessageHandlerList.Add(httpClientHandler);
                        }
                    }
                });
            }
        }


        // Class
        public class SettingDictionary : Dictionary<string, Setting>
        {

        }

        public class Setting
        {
            // Properties
            public string BaseAddress { get; set; } = string.Empty;

            public bool UseCookies { get; set; } = false;

            public bool IgnoreServerCertificate { get; set; } = false;

            public List<string> Handlers { get; set; } = new List<string>();

            public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }
    }
}
