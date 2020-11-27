namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    internal class EventPropertyInformation
    {
        public string Name { get; }
        public string Description { get; }

        public EventPropertyInformation(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
