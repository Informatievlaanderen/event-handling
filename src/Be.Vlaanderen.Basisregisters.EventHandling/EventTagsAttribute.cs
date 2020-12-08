namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EventTagsAttribute : Attribute
    {
        public IEnumerable<EventTag> Tags { get; }

        public EventTagsAttribute(params EventTag[] eventTags)
            => Tags = eventTags?.Where(t => t != null) ?? new EventTag[0];
    }
}
