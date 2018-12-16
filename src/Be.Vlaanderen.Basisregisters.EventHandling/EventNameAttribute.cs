namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EventNameAttribute : Attribute
    {
        public string Value { get; }

        public EventNameAttribute(string eventName) => Value = eventName;
    }
}
