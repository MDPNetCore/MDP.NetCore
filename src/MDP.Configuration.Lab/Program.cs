﻿using Microsoft.Extensions.Configuration;
using System;

namespace MDP.Configuration.Lab
{
    public class Program
    {
        // Methods
        public static void Main(string[] args)
        {
            // EnvironmentName
            var environmentName = "Production";
            //var environmentName = "Staging";
            //var environmentName = "Development";

            // ConfigurationBuilder
            var configurationBuilder = new ConfigurationBuilder();
            {
                // Register
                configurationBuilder.RegisterModule(environmentName);
            }
            var configuration = configurationBuilder.Build();
            if (configuration == null) throw new InvalidOperationException($"{nameof(configuration)}=null");

            // Bind
            var setting = configuration.Bind<Setting>("MDP.Module01:Setting");
            if (setting == null) throw new InvalidOperationException($"{nameof(setting)}=null");

            // Display
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(setting, Newtonsoft.Json.Formatting.Indented));
        }

        // Class
        public class Setting
        {
            // Properties
            public string MessageA { get; set; } = string.Empty;

            public string MessageB { get; set; } = string.Empty;

            public string MessageC { get; set; } = string.Empty;
        }
    }
}
