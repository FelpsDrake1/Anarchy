﻿using Newtonsoft.Json;
using System.Collections.Generic;
using Discord.Webhook;

namespace Discord
{
    public class BasicGuild
    {
        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonIgnore]
        internal virtual DiscordClient Client { get; set; }


        public bool Delete()
        {
            return Client.DeleteGuild(Id);
        }


        public bool KickMember(long userId)
        {
            return Client.KickGuildMember(Id, userId);
        }


        public bool KickMember(User user)
        {
            return KickMember(user.Id);
        }


        public List<Channel> GetChannels()
        {
            return Client.GetGuildChannels(Id);
        }


        public virtual List<Reaction> GetReactions()
        {
            return Client.GetGuildReactions(Id);
        }


        public Reaction GetReaction(long reactionId)
        {
            return Client.GetGuildReaction(Id, reactionId);
        }


        public virtual List<Role> GetRoles()
        {
            return Client.GetGuildRoles(Id);
        }


        public List<Invite> GetInvites()
        {
            return Client.GetGuildInvites(Id);
        }


        public Channel CreateChannel(ChannelCreationProperties properties)
        {
            return Client.CreateChannel(Id, properties);
        }


        public Reaction CreateReaction(ReactionCreationProperties properties)
        {
            return Client.CreateGuildReaction(Id, properties);
        }


        public Role CreateRole()
        {
            return Client.CreateGuildRole(Id);
        }


        public List<Hook> GetWebhooks()
        {
            return Client.GetGuildWebhooks(Id);
        }


        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}