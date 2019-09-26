namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class EventMapping
    {
        private readonly IReadOnlyDictionary<string, Type> _eventNameTypeMapping;
        private readonly IReadOnlyDictionary<Type, string> _typeEventNameMapping;

        public EventMapping(IReadOnlyDictionary<string, Type> eventTypeMapping)
        {
            if (eventTypeMapping == null) throw new ArgumentNullException(nameof(eventTypeMapping));

            _eventNameTypeMapping = eventTypeMapping.ToDictionary(x => x.Key, x => x.Value);
            _typeEventNameMapping = eventTypeMapping.ToDictionary(x => x.Value, x => x.Key);
        }

        public static IReadOnlyDictionary<string, Type> DiscoverEventNamesInAssembly(Assembly assemblyToScan)
        {
            var types =
                from t in assemblyToScan.GetTypes().AsParallel()
                let attributes = t.GetCustomAttributes(typeof(EventNameAttribute), true)
                where attributes != null && attributes.Length == 1
                select new { Type = t, EventName = attributes.Cast<EventNameAttribute>().Single().Value };

            return types.ToDictionary(x => x.EventName, x => x.Type);
        }

        public Type GetEventType(string eventName)
        {
            if (_eventNameTypeMapping.ContainsKey(eventName))
                return _eventNameTypeMapping[eventName];

            throw new KeyNotFoundException($"Type voor event met naam '{eventName}' niet gevonden.");
        }

        public bool TryGetEventType(string eventName, out Type eventType) =>
            _eventNameTypeMapping.TryGetValue(eventName, out eventType);

        public string GetEventName(Type eventType)
        {
            if (_typeEventNameMapping.ContainsKey(eventType))
                return _typeEventNameMapping[eventType];

            throw new KeyNotFoundException($"Naam voor event met type '{eventType}' niet gevonden.");
        }

        public bool TryGetEventName(Type eventType, out string eventName) =>
            _typeEventNameMapping.TryGetValue( eventType, out eventName);
    }
}
