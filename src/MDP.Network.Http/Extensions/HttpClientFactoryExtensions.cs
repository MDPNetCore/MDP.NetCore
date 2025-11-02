using MDP.Registration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.Network.Http
{
    public static class HttpClientFactoryExtensions
    {
        // Methods
        public static IHttpClientBuilder AddHttpClient(this IServiceCollection serviceCollection,
            string name,
            string baseAddress = "",
            Dictionary<string, string> headers = null,
            List<HttpClientHandler> handlers = null,
            bool useCookies = false,
            bool ignoreServerCertificate = false
        )
        {
            #region Contracts

            ArgumentNullException.ThrowIfNull(serviceCollection);
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            ArgumentNullException.ThrowIfNullOrEmpty(baseAddress);

            #endregion

            // Require
            if (baseAddress.EndsWith(@"/") == false) baseAddress += @"/";
            if (headers == null) headers = new Dictionary<string, string>();
            if (handlers == null) handlers = new List<HttpClientHandler>();

            // HttpClientBuilder
            var httpClientBuilder = serviceCollection.AddHttpClient(name, httpClient =>
            {
                // BaseAddress
                httpClient.BaseAddress = new Uri(baseAddress);

                // Headers
                foreach (var header in headers)
                {
                    // Add
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            });

            // System.Net.Http.HttpClientHandler
            httpClientBuilder = httpClientBuilder.ConfigurePrimaryHttpMessageHandler(serviceProvider =>
            {
                // HttpClientHandler
                var httpClientHandler = new System.Net.Http.SocketsHttpHandler();

                // UseCookies
                httpClientHandler.UseCookies = useCookies;

                // IgnoreCertificates
                if (ignoreServerCertificate == true)
                {
                    httpClientHandler.SslOptions.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return false; };
                }

                // Return
                return httpClientHandler;
            });

            // MDP.Network.Http.HttpClientHandler
            if (headers.Count > 0)
            {
                httpClientBuilder = httpClientBuilder.ConfigureAdditionalHttpMessageHandlers((httpMessageHandlerList, serviceProvider) =>
                {
                    // HttpClientHandler
                    foreach (var handler in handlers)
                    {
                        // Add
                        httpMessageHandlerList.Add(handler);
                    }
                });
            }

            // Return
            return httpClientBuilder;
        }
    }
}
