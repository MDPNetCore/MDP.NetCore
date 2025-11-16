using MDP.Network.Http;
using MDP.Registration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public static class HttpClientExtensions
    {
        // Methods
        public static HttpClient CreateMessageClient(this IHttpClientFactory httpClientFactory)
        {
            #region Contracts

            ArgumentNullException.ThrowIfNull(httpClientFactory);

            #endregion

            // MessageClient
            var messageClient = httpClientFactory.CreateClient(HttpClientDefaults.MessageClientId);
            if (messageClient == null) throw new InvalidOperationException($"{nameof(messageClient)}=null");

            // Return
            return messageClient;
        }

        public static HttpClient CreateContentClient(this IHttpClientFactory httpClientFactory)
        {
            #region Contracts

            ArgumentNullException.ThrowIfNull(httpClientFactory);

            #endregion

            // ContentClient
            var contentClient = httpClientFactory.CreateClient(HttpClientDefaults.ContentClientId);
            if (contentClient == null) throw new InvalidOperationException($"{nameof(contentClient)}=null");

            // Return
            return contentClient;
        }
    }
}
