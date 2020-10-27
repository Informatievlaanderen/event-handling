namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class EventPropertyDescriptionAttribute : Attribute
    {
        public string Value { get; }

        public EventPropertyDescriptionAttribute(string eventPropertyDescription) => Value = eventPropertyDescription;
    }
}
