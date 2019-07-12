﻿using Newtonsoft.Json;

namespace Discord
{
    public class Relationship : Controllable
    {
        public Relationship()
        {
            OnClientUpdated += (sender, e) => User.SetClient(Client);
        }

        [JsonProperty("user")]
        public User User { get; private set; }


        [JsonProperty("type")]
        public RelationshipType Type { get; internal set; }


        public void Remove()
        {
            Client.RemoveRelationship(User.Id);
        }


        public override string ToString()
        {
            return $"{Type} {User}";
        }
    }
}