namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System.Collections.Generic;
    using System.Text;

    public interface IRegistryEventsMarkdownGenerator
    {
        string Generate();
		
        string GenerateFor(IEnumerable<EventTag> tags);
		
        internal IRegistryEventsMarkdownGenerator CreateDuplicateUsing(StringBuilder externalMarkdownBuilder);
    }
}
