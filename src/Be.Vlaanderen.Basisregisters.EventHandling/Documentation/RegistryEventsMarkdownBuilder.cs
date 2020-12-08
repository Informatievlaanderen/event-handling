namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using EventHandling;

    public class RegistryEventsMarkdownGenerator<TAssemblyMarker> : IRegistryEventsMarkdownGenerator
    {
        private readonly string _registryName;
        private readonly Func<StringBuilder> _markdownStringBuilderFactory;

        private RegistryEventsMarkdownGenerator(
            string registryName,
            Func<StringBuilder> markdownStringBuilderFactory)
        {
            _registryName = registryName;
            _markdownStringBuilderFactory = markdownStringBuilderFactory;
        }

        public RegistryEventsMarkdownGenerator(string registryName)
            : this(registryName, () => new StringBuilder())
        { }

        public string Generate()
        {
            var builder = _markdownStringBuilderFactory();

            var events = typeof(TAssemblyMarker)
                .GetTypeInfo()
                .Assembly
                .GetExportedTypes()
                .Where(IsClassWithAttribute<EventNameAttribute>)
                .Select(CreateEventInformation);

            builder
                .AppendRegistry(_registryName)
                .AppendInfo(events);

            return builder.ToString();
        }

        IRegistryEventsMarkdownGenerator IRegistryEventsMarkdownGenerator.CreateDuplicateUsing(StringBuilder externalMarkdownBuilder)
            => new RegistryEventsMarkdownGenerator<TAssemblyMarker>(_registryName, () => externalMarkdownBuilder);

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
