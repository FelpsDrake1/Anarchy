﻿using Newtonsoft.Json;

namespace Discord.Gateway
{
    internal class GatewayResponse
    {
        [JsonProperty("op")]
        public GatewayOpcode Opcode { get; private set; }

        [JsonProperty("t")]
        public string Title { get; private set; }

        [JsonProperty("d")]
        public object Data { get; private set; }

        [JsonProperty("s")]
        public int? Sequence { get; private set; }
    }
}