namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EventTagsAttribute : Attribute
    {
        public IEnumerable<EventTag> Tags { get; }

        public EventTagsAttribute(params string[] eventTags)
            => Tags = eventTags
                ?.Where(tag => !string.IsNullOrWhiteSpace(tag))
                .Select(EventTag.Create) ?? new List<EventTag>();
    }
}
