﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MDP.Messaging.Notifications
{
    public class Registration
    {
        // Properties
        public string UserId { get; set; }

        public string DeviceType { get; set; }

        public string Token { get; set; }


        // Methods
        public bool IsValid()
        {
            // UserId
            if (string.IsNullOrEmpty(this.UserId) == true) return false;

            // DeviceType
            if (string.IsNullOrEmpty(this.DeviceType) == true) return false;

            // Token
            if (string.IsNullOrEmpty(this.Token) == true) return false;


            // Return
            return true;
        }
    }
}