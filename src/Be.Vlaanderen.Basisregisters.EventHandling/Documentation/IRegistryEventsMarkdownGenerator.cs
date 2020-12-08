namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System.Text;

    public interface IRegistryEventsMarkdownGenerator
    {
        string Generate();
        internal IRegistryEventsMarkdownGenerator CreateDuplicateUsing(StringBuilder externalMarkdownBuilder);
    }
}
