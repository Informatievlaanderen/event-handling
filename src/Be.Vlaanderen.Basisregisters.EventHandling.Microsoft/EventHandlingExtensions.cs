namespace Be.Vlaanderen.Basisregisters.EventHandling.Microsoft
{
    using System.Reflection;
    using global::Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    public static class EventHandlingExtensions
    {
        public static IServiceCollection ConfigureEventHandling(
            this IServiceCollection serviceCollection,
            Assembly eventsAssembly,
            JsonSerializerSettings jsonSerializerSettingsForEvents)
        {
            var eventDeserializer = new EventDeserializer((eventData, eventType) =>
                JsonConvert.DeserializeObject(eventData, eventType, jsonSerializerSettingsForEvents));
            var eventSerializer = new EventSerializer(@event =>
                JsonConvert.SerializeObject(@event, jsonSerializerSettingsForEvents));
            var eventMapping = new EventMapping(EventMapping.DiscoverEventNamesInAssembly(eventsAssembly));

            serviceCollection.AddTransient(_ => eventMapping);
            serviceCollection.AddTransient(_ => eventDeserializer);
            serviceCollection.AddTransient(_ => eventSerializer);

            return serviceCollection;
        }
    }
}
