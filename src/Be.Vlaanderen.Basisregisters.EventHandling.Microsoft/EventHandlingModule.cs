namespace Be.Vlaanderen.Basisregisters.EventHandling.Microsoft
{
    using System.Reflection;
    using DependencyInjection;
    using global::Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    public class EventHandlingModule : IServiceCollectionModule
    {
        private readonly EventDeserializer _eventDeserializer;
        private readonly EventSerializer _eventSerializer;
        private readonly EventMapping _eventMapping;

        public EventHandlingModule(Assembly eventsAssembly, JsonSerializerSettings jsonSerializerSettingsForEvents)
        {
            _eventDeserializer = new EventDeserializer((eventData, eventType) => JsonConvert.DeserializeObject(eventData, eventType, jsonSerializerSettingsForEvents));
            _eventSerializer = new EventSerializer(@event => JsonConvert.SerializeObject(@event, jsonSerializerSettingsForEvents));
            _eventMapping = new EventMapping(EventMapping.DiscoverEventNamesInAssembly(eventsAssembly));
        }

        public void Load(IServiceCollection services)
        {
            services.AddTransient(_ => _eventMapping);

            services.AddTransient(_ => _eventDeserializer);

            services.AddTransient(_ => _eventSerializer);
        }
    }
}
