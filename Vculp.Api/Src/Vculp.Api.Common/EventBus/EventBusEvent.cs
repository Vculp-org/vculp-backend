using System;

namespace Vculp.Api.Common.EventBus
{
    public class EventBusEvent
    {
        public EventBusEvent(
            string eventType,
            object payload)
        {
            if (string.IsNullOrWhiteSpace(eventType))
            {
                throw new ArgumentException($"{nameof(eventType)} cannot be null, empty or contain only whitespace", nameof(eventType));
            }

            EventType = eventType;
            Payload = payload ?? throw new ArgumentNullException(nameof(payload));
        }

        public string EventType { get; }
        public object Payload { get; }
    }
}
