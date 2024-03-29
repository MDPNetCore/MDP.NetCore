﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.Logging.Log4net
{
    public class Log4netLoggerSetting
    {
        // Properties
        public string ConfigFileName { get; set; } = "log4net.config";

        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}
