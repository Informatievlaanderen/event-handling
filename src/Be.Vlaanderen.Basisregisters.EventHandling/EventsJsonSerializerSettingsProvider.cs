namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Helper class which provides <see cref="EventsJsonSerializerSettingsProvider"/>.
    /// </summary>
    public static class EventsJsonSerializerSettingsProvider
    {
        private const int DefaultMaxDepth = 32;

        // return shared resolver by default for perf so slow reflection logic is cached once
        // developers can set their own resolver after the settings are returned if desired
        private static readonly DefaultContractResolver SharedContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy(),
        };

        /// <summary>
        /// Creates default <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <returns>Default <see cref="JsonSerializerSettings"/>.</returns>
        public static JsonSerializerSettings CreateSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = SharedContractResolver,

                MissingMemberHandling = MissingMemberHandling.Ignore,

                // Limit the object graph we'll consume to a fixed depth. This prevents stackoverflow exceptions
                // from deserialization errors that might occur from deeply nested objects.
                MaxDepth = DefaultMaxDepth,

                // Do not change this setting
                // Setting this to None prevents Json.NET from loading malicious, unsafe, or security-sensitive types
                TypeNameHandling = TypeNameHandling.None,
            }.ConfigureDefaultForEvents();
        }
    }
}
