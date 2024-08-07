﻿using MDP.Registration;
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

                // HttpClientHandler
                httpClientBuilder = httpClientBuilder.ConfigurePrimaryHttpMessageHandler(serviceProvider =>
                {
                    // Create
                    var httpClientHandler = new HttpClientHandler();
                    {
                        // UseCookies
                        httpClientHandler.UseCookies = setting.Value.UseCookies;

                        // IgnoreCertificates
                        if (setting.Value.IgnoreServerCertificate == true)
                        {
                            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                        }
                    }

                    // Return
                    return httpClientHandler;
                });

                // HttpDelegatingHandler
                foreach (var handler in setting.Value.Handlers)
                {
                    // Add
                    httpClientBuilder = httpClientBuilder.AddHttpMessageHandler(serviceProvider =>
                    {
                        // Resolve
                        var httpDelegatingHandler = serviceProvider.ResolveNamed<HttpDelegatingHandler>(handler);
                        if (httpDelegatingHandler == null) throw new InvalidOperationException($"{nameof(httpDelegatingHandler)}=null");

                        // Return
                        return httpDelegatingHandler;
                    });
                }
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
