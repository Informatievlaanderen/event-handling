namespace Be.Vlaanderen.Basisregisters.EventHandling.Microsoft
{
    using System.Reflection;
    using DependencyInjection;
    using global::Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    public class EventHandlingModule : IServiceCollectionModule
    {
        private readonly Assembly _eventsAssembly;
        private readonly JsonSerializerSettings _jsonSerializerSettingsForEvents;

        public EventHandlingModule(Assembly eventsAssembly, JsonSerializerSettings jsonSerializerSettingsForEvents)
        {
            _eventsAssembly = eventsAssembly;
            _jsonSerializerSettingsForEvents = jsonSerializerSettingsForEvents;
        }

        public void Load(IServiceCollection services)
        {
            services.ConfigureEventHandling(_eventsAssembly, _jsonSerializerSettingsForEvents);
        }
    }
}
