namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using EventHandling;

    public class RegistryEventsMarkdownGenerator<TAssemblyMarker> : IRegistryEventsMarkdownGenerator
    {
        private readonly string _registryName;
        private readonly Func<StringBuilder> _getMarkdownStringBuilder;

        private RegistryEventsMarkdownGenerator(
            string registryName,
            Func<StringBuilder> markdownStringBuilderFactory)
        {
            _registryName = registryName;
            _getMarkdownStringBuilder = markdownStringBuilderFactory;
        }

        public RegistryEventsMarkdownGenerator(string registryName)
            : this(registryName, () => new StringBuilder())
        { }

        public string Generate()
            => GenerateFor(new List<EventTag>());

        public string GenerateFor(IEnumerable<EventTag> tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var events = typeof(TAssemblyMarker)
                .GetTypeInfo()
                .Assembly
                .GetExportedTypes()
                .Where(IsClassWithAttribute<EventNameAttribute>)
                .Where(t => !IsClassWithAttribute<HideEventAttribute>(t))
                .Where(HasEventTags(tags.ToList()))
                .Select(CreateEventInformation);

            return _getMarkdownStringBuilder()
                .AppendRegistry(_registryName)
                .AppendInfo(events)
                .ToString();
        }

        IRegistryEventsMarkdownGenerator IRegistryEventsMarkdownGenerator.CreateDuplicateUsing(StringBuilder externalMarkdownBuilder)
            => new RegistryEventsMarkdownGenerator<TAssemblyMarker>(_registryName, () => externalMarkdownBuilder);

        private static bool IsClassWithAttribute<TAttribute>(Type type)
            where TAttribute : Attribute
            => type.IsClass && type.GetCustomAttribute<TAttribute>() != null;

        private static Func<Type, bool> HasEventTags(IReadOnlyList<EventTag> requestedTags)
        {
            if (requestedTags == null)
                throw new ArgumentNullException(nameof(requestedTags));

            return requestedTags.Count == 0
                ? _ => true
                : HasAnyRequestedEventTag;

            bool HasAnyRequestedEventTag(Type eventType)
            {
                var eventTags = eventType
                    .GetCustomAttribute<EventTagsAttribute>()
                    ?.Tags
                    .ToList();

                return eventTags != null && requestedTags.Any(eventTags.Contains);
            }
        }

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
