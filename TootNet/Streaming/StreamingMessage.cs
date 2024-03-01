using System;
using TootNet.Objects;

namespace TootNet.Streaming
{
    public class StreamingMessage
    {
        public enum MessageType
        {
            Status = 0,
            StatusDelete = 1,
            Notification = 2,
            FiltersChanged = 3,
            Conversation = 4,
            Announcement = 5,
            AnnouncementReaction = 6,
            AnnouncementDelete = 7,
            StatusUpdate = 8,
        }

        public StreamingMessage(MessageType msgType)
        {
            Type = msgType;
        }

        public StreamingMessage(MessageType msgType, Status status) : this(msgType)
        {
            switch (msgType)
            {
                case MessageType.Status:
                    Status = status;
                    break;
                case MessageType.StatusUpdate:
                    UpdatedStatus = status;
                    break;
                default:
                    throw new ArgumentException("Invalid message type received");
            }
        }

        public StreamingMessage(MessageType msgType, Notification notification) : this(msgType)
        {
            if (msgType != MessageType.Notification)
                throw new ArgumentException("Invalid message type received");

            Notification = notification;
        }

        public StreamingMessage(MessageType msgType, Conversation conversation) : this(msgType)
        {
            if (msgType != MessageType.Conversation)
                throw new ArgumentException("Invalid message type received");

            Conversation = conversation;
        }

        public StreamingMessage(MessageType msgType, Announcement announcement) : this(msgType)
        {
            if (msgType != MessageType.Announcement)
                throw new ArgumentException("Invalid message type received");

            Announcement = announcement;
        }

        public StreamingMessage(MessageType msgType, Reaction announcementReaction) : this(msgType)
        {
            if (msgType != MessageType.AnnouncementReaction)
                throw new ArgumentException("Invalid message type received");

            AnnouncementReaction = announcementReaction;
        }

        public StreamingMessage(MessageType msgType, long id) : this(msgType)
        {
            switch (msgType)
            {
                case MessageType.StatusDelete:
                    DeletedStatusId = id;
                    break;
                case MessageType.AnnouncementDelete:
                    DeletedAnnouncementId = id;
                    break;
                default:
                    throw new ArgumentException("Invalid message type received");
            }
        }

        public MessageType Type { get; set; }

        public Status Status { get; set; }
        public Status UpdatedStatus { get; set; }
        public long? DeletedStatusId { get; set; }
        public Notification Notification { get; set; }
        public Conversation Conversation { get; set; }
        public Announcement Announcement { get; set; }
        public Reaction AnnouncementReaction { get; set; }
        public long? DeletedAnnouncementId { get; set; }
    }
}
