﻿using Discord.Webhook;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    /// <summary>
    /// Represents a <see cref="Channel"/> specific to guild text channels
    /// </summary>
    public class TextChannel : GuildChannel
    {
        [JsonProperty("topic")]
        public string Topic { get; private set; }


        [JsonProperty("nsfw")]
        public bool Nsfw { get; private set; }


        private int _slowMode;
        [JsonProperty("rate_limit_per_user")]
        public int SlowMode
        {
            get { return _slowMode; }
            private set { _slowMode = value * 10; } //convert to milliseconds
        }


        /// <summary>
        /// Updates the channel's info
        /// </summary>
        public override void Update()
        {
            TextChannel channel = Client.GetTextChannel(Id);
            Name = channel.Name;
            Topic = channel.Topic;
            Nsfw = channel.Nsfw;
            Position = channel.Position;
            ParentId = channel.ParentId;
            PermissionOverwrites = channel.PermissionOverwrites;
        }


        /// <summary>
        /// Modifies the channel
        /// </summary>
        /// <param name="properties">Options for modifying the channel</param>
        public void Modify(TextChannelProperties properties)
        {
            if (!properties.NameProperty.Set)
                properties.Name = Name;
            if (!properties.TopicProperty.Set)
                properties.Topic = Topic;
            if (!properties.NsfwProperty.Set)
                properties.Nsfw = Nsfw;
            if (!properties.SlowModeProperty.Set)
                properties.SlowMode = SlowMode;
            if (!properties.PositionProperty.Set)
                properties.Position = Position;
            if (!properties.ParentProperty.Set)
                properties.ParentId = ParentId;

            TextChannel channel = Client.ModifyTextChannel(Id, properties);
            Name = channel.Name;
            Topic = channel.Topic;
            Nsfw = channel.Nsfw;
            SlowMode = channel.SlowMode;
            Position = channel.Position;
            ParentId = channel.ParentId;
            PermissionOverwrites = channel.PermissionOverwrites;
        }


        #region messages
        /// <summary>
        /// Triggers a 'user typing...'
        /// </summary>
        public void TriggerTyping()
        {
            Client.TriggerTyping(Id);
        }


        /// <summary>
        /// Sends a message to the channel
        /// </summary>
        /// <param name="message">Content of the message</param>
        /// <param name="tts">Whether the message should be TTS or not</param>
        /// <returns>The message</returns>
        public Message SendMessage(string message, bool tts = false, Embed embed = null)
        {
            return Client.SendMessage(Id, message, tts, embed);
        }


        /// <summary>
        /// Gets a list of messages in the channel
        /// </summary>
        /// <param name="limit">The max amount of messages to return</param>
        /// <param name="afterId">The ID to offset from</param>
        public IReadOnlyList<Message> GetMessages(uint limit = 100, uint afterId = 0)
        {
            return Client.GetChannelMessages(Id, limit, afterId);
        }


        /// <summary>
        /// Gets the channel's pinned messages
        /// </summary>
        public IReadOnlyList<Message> GetPinnedMessages()
        {
            return Client.GetChannelPinnedMessages(Id);
        }


        /// <summary>
        /// Pins a message to the channel
        /// </summary>
        /// <param name="messageId">ID of the message</param>
        public void PinMessage(ulong messageId)
        {
            Client.PinChannelMessage(Id, messageId);
        }


        /// <summary>
        /// Pins a message to the channel
        /// </summary>
        public void PinMessage(Message message)
        {
            PinMessage(message.Id);
        }


        /// <summary>
        /// Unpins a message from the channel
        /// </summary>
        /// <param name="messageId">ID of the message</param>
        public void UnpinMessage(ulong messageId)
        {
            Client.UnpinChannelMessage(Id, messageId);
        }


        /// <summary>
        /// Unpins a message from the channel
        /// </summary>
        public void UnpinMessage(Message message)
        {
            Client.UnpinChannelMessage(Id, message.Id);
        }
        #endregion


        /// <summary>
        /// Creates an invite for the channel
        /// </summary>
        /// <param name="properties">Options for creating the invite</param>
        /// <returns>The created invite</returns>
        public PartialInvite CreateInvite(InviteProperties properties = null)
        {
            return Client.CreateInvite(Id, properties);
        }


        /// <summary>
        /// Gets the channel's webhooks
        /// </summary>
        public IReadOnlyList<Hook> GetWebhooks()
        {
            return Client.GetChannelWebhooks(Id);
        }


        /// <summary>
        /// Creates a webhook
        /// </summary>
        /// <param name="properties">Options for creating/modifying the webhook</param>
        /// <returns>The created webhook</returns>
        public Hook CreateWebhook(WebhookProperties properties)
        {
            return Client.CreateChannelWebhook(Id, properties);
        }
    }
}
