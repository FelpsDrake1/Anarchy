﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Discord
{
    public class Message : Controllable
    {
        public Message()
        {
            OnClientUpdated += (sender, e) =>
            {
                Reactions.SetClientsInList(Client);
                Author.SetClient(Client);
            };
        }

        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("content")]
        public string Content { get; private set; }

        [JsonProperty("tts")]
        public bool Tts { get; private set; }

        [JsonProperty("author")]
        public User Author { get; private set; }

        [JsonProperty("type")]
        public MessageType Type { get; private set; }

        [JsonProperty("attachments")]
        public IReadOnlyList<Attachment> Attachments { get; private set; }

        [JsonProperty("embeds")]
        public IReadOnlyList<Embed> Embeds { get; private set; }

        [JsonProperty("reactions")]
        public IReadOnlyList<MessageReaction> Reactions { get; private set; }

        [JsonProperty("mentions")]
        public IReadOnlyList<User> Mentions { get; private set; }

        [JsonProperty("mention_roles")]
        public IReadOnlyList<long> MentionedRoles { get; private set; }

        [JsonProperty("mention_everyone")]
        public bool MentionedEveryone { get; private set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; private set; }
        
        [JsonProperty("pinned")]
        public bool Pinned { get; private set; }
      
        [JsonProperty("channel_id")]
        public long ChannelId { get; private set; }

        [JsonProperty("guild_id")]
        public long? GuildId { get; private set; }


        public Message Edit(string message)
        {
            Message msg = Client.EditMessage(ChannelId, Id, message);
            Content = msg.Content;
            Pinned = msg.Pinned;
            Mentions = msg.Mentions;
            MentionedRoles = msg.MentionedRoles;
            MentionedEveryone = msg.MentionedEveryone;
            Embeds = msg.Embeds;
            return msg;
        }


        public bool Delete()
        {
            return Client.DeleteMessage(ChannelId, Id);
        }


        public IReadOnlyList<User> GetReactions(string reaction, int limit = 25, int afterId = 0)
        {
            return Client.GetMessageReactions(ChannelId, Id, reaction, limit, afterId);
        }


        public bool AddReaction(string reaction)
        {
            return Client.AddMessageReaction(ChannelId, Id, reaction);
        }


        public bool RemoveReaction(string reaction)
        {
            return Client.RemoveMessageReaction(ChannelId, Id, reaction);
        }


        public override string ToString()
        {
            return Author.ToString();
        }
    }
}