using System;

namespace Snowman.Tourist.Spots.Shared.Domain.Messages
{
    public abstract class Message 
    {
        protected Message()
        {
            Timestamp = DateTime.UtcNow;
            MessageType = GetType().Name;
        }

        public DateTime Timestamp { get; private set; }
        public string MessageType { get; private set; }
        public Guid UserId { get; private set; }

        public void SetUser(Guid userId) => UserId = userId;
    }
}
