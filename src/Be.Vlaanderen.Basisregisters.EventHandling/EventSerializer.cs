using System;

namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    public class EventSerializer
    {
        private readonly Func<object, string> _eventSerializer;

        public EventSerializer(Func<object, string> eventSerializer)
            => _eventSerializer = eventSerializer;

        public string SerializeObject(object @event)
        {
            if (_eventSerializer == null)
                throw new InvalidOperationException("De event serializer is nog niet geconfigureerd.");

            return _eventSerializer(@event);
        }
    }
}
