namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using Converters.TrimString;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    using NodaTime;
    using NodaTime.Serialization.JsonNet;

    public static class SerializerSettingsExtensions
    {
        private static readonly DefaultContractResolver SharedEventsContractResolver =
            new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = true,
                    ProcessDictionaryKeys = true,
                    ProcessExtensionDataNames = true
                }
            };

        /// <summary>
        /// Sets up and adds additional converters for events to the JsonSerializerSettings
        /// </summary>
        /// <param name="source"></param>
        /// <returns>the updated JsonSerializerSettings</returns>
        public static JsonSerializerSettings ConfigureDefaultForEvents(this JsonSerializerSettings source)
        {
            source.ContractResolver = SharedEventsContractResolver;

            source.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            source.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            source.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy()});
            source.Converters.Add(new TrimStringConverter());

            return source
                .ConfigureForNodaTime(DateTimeZoneProviders.Tzdb)
                .WithIsoIntervalConverter();
        }
    }
}
