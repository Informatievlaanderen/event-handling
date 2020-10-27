namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EventTagsAttribute : Attribute
    {
        public string[] Tags { get; }

        public EventTagsAttribute(params string[] eventTags) => Tags = eventTags ?? new string[0];
    }
}
