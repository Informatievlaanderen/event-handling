using System;

namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    public class EventDeserializer
    {
        private readonly Func<string, Type, object?> _eventDeserializer;

        public EventDeserializer(Func<string, Type, object?> eventDeserializer)
            => _eventDeserializer = eventDeserializer;

        public object? DeserializeObject(string eventData, Type eventType)
        {
            if (_eventDeserializer == null)
                throw new InvalidOperationException("De event deserializer is nog niet geconfigureerd.");

            return _eventDeserializer(eventData, eventType);
        }
    }
}
