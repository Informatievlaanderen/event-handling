namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EventDescriptionAttribute : Attribute
    {
        public string Value { get; }

        public EventDescriptionAttribute(string eventDescription) => Value = eventDescription;
    }
}
