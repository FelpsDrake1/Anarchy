﻿using Newtonsoft.Json;

namespace Discord.Gateway
{
    /// <summary>
    /// Information about a user login
    /// </summary>
    internal class GatewayLogin
    {
        [JsonProperty("session_id")]
        internal string SessionId { get; private set; }

        [JsonProperty("user")]
        public ClientUser User { get; private set; }

        public override string ToString()
        {
            return $"{User} ({User.Id})";
        }
    }
}