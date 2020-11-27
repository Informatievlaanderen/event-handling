namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System.Collections.Generic;
    using System.Linq;

    internal class EventInformation
    {
        public string Name { get; }
        public string Description { get; }
        public IEnumerable<EventPropertyInformation> Properties { get; }

        public EventInformation(string name, string description, IEnumerable<EventPropertyInformation> properties)
        {
            Name = name;
            Description = description;
            Properties = properties.ToList();
        }
    }
}
