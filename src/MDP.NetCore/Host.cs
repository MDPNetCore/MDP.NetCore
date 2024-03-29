﻿using Microsoft.Extensions.Hosting;
using System;

namespace MDP.NetCore
{
    public static class Host
    {
        // Methods
        public static void Run<TProgram>(string[] args) where TProgram : class
        {
            #region Contracts

            if (args == null) throw new ArgumentException($"{nameof(args)}=null");

            #endregion

            // HostBuilder
            var hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args).ConfigureMDP<TProgram>();
            if (hostBuilder == null) throw new InvalidOperationException($"{nameof(hostBuilder)}=null");

            // Host
            var host = hostBuilder.Build();
            if (host == null) throw new InvalidOperationException($"{nameof(host)}=null");

            // Run
            host.Run();
        }
    }
}
