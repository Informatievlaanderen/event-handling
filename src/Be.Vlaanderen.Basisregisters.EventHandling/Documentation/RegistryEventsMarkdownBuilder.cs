namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using EventHandling;

    public interface IRegistryEventsMarkdownGenerator
    {
        string Generate();
        void WriteTo(StringBuilder builder);
    }

    public class RegistryEventsMarkdownGenerator<TAssemblyMarker> : IRegistryEventsMarkdownGenerator
    {
        private readonly string _registryName;

        public RegistryEventsMarkdownGenerator(string registryName)
            => _registryName = registryName;

        public string Generate()
        {
            var builder = new StringBuilder();
            WriteTo(builder);
            return builder.ToString();
        }

        public void WriteTo(StringBuilder builder)
        {
            var events = typeof(TAssemblyMarker)
                .GetTypeInfo()
                .Assembly
                .GetExportedTypes()
                .Where(IsClassWithAttribute<EventNameAttribute>)
                .Select(CreateEventInformation);

            builder
                .AppendRegistry(_registryName)
                .AppendInfo(events);
        }

        private static bool IsClassWithAttribute<TAttribute>(Type type)
            where TAttribute : Attribute
            => type.IsClass && type.GetCustomAttribute<TAttribute>() != null;

        private static EventInformation CreateEventInformation(Type eventType)
            => new EventInformation(
                eventType.GetCustomAttribute<EventNameAttribute>()?.Value ?? string.Empty,
                eventType.GetCustomAttribute<EventDescriptionAttribute>()?.Value ?? string.Empty,
                eventType.GetProperties().Select(CreatePropertyInformation));

        private static EventPropertyInformation CreatePropertyInformation(PropertyInfo eventPropertyInfo) =>
            new EventPropertyInformation(
                eventPropertyInfo.Name,
                eventPropertyInfo.GetCustomAttribute<EventPropertyDescriptionAttribute>()?.Value ?? string.Empty);
    }
}
