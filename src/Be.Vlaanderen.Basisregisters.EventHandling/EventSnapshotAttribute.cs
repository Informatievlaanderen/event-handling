using System;

namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EventSnapshotAttribute : Attribute
    {
        public string EventName { get; }
        public Type SnapshotType { get; }

        public EventSnapshotAttribute(string eventName, Type snapshotType)
        {
            EventName = eventName;
            SnapshotType = snapshotType;
        }
    }
}
