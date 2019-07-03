﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord.Gateway
{
    public class GatewayLogin : Controllable
    {
        public GatewayLogin()
        {
            OnClientUpdated += (sender, e) =>
            {
                User.SetClient(Client);
                Guilds.SetClientsInList(Client);
            };
        }

        [JsonProperty("user")]
        public ClientUser User { get; private set; }

        //if you're using a bot token only the id will be filled in. actual full guild comes in GUILD_CREATE events
        [JsonProperty("guilds")]
        public IReadOnlyList<Guild> Guilds { get; private set; }

        [JsonProperty("relationships")]
        public List<Relationship> Relationships { get; private set; }


        public override string ToString()
        {
            return User.ToString();
        }
    }
}