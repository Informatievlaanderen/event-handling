namespace Be.Vlaanderen.Basisregisters.EventHandling.Autofac
{
    using System.Reflection;
    using global::Autofac;
    using Newtonsoft.Json;
    using Module = global::Autofac.Module;

    public class EventHandlingModule : Module
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

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterInstance(_eventMapping)
                .As<EventMapping>();

            builder
                .RegisterInstance(_eventDeserializer)
                .As<EventDeserializer>();

            builder
                .RegisterInstance(_eventSerializer)
                .As<EventSerializer>();
        }
    }
}
