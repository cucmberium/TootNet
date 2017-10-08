using System;
using System.Collections.Generic;
using System.Text;
using TootNet.Objects;

namespace TootNet.Streaming
{
    public class StreamingMessage
    {
        public enum MessageType
        {
            DeleteStatus = 0,
            Status = 1,
            Notification = 2
        }
        
        public StreamingMessage(Status status)
        {
            Type = MessageType.Status;
            Status = status;
        }

        public StreamingMessage(Notification notification)
        {
            Type = MessageType.Notification;
            Notification = notification;
        }

        public StreamingMessage(long id)
        {
            Type = MessageType.DeleteStatus;
            DeletedId = id;
        }

        public MessageType Type { get; set; }

        public Status Status { get; set; }
        public Notification Notification { get; set; }
        public long DeletedId { get; set; }
    }
}
