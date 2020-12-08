namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System.Collections.Generic;
    using System.Text;

    public static class RegistryEventsMarkdownGeneratorCollectionExtensions
    {
        public static string Generate(this IEnumerable<IRegistryEventsMarkdownGenerator> markdownGenerators)
        {
            var markdownBuilder = new StringBuilder();
            using (var generators = markdownGenerators.GetEnumerator())
            {
                var next = generators.MoveNext();
                while (next)
                {
                    generators
                        .Current
                        ?.CreateDuplicateUsing(markdownBuilder)
                        .Generate();

                    next = generators.MoveNext();
                    if (next)
                        markdownBuilder.AppendLine();
                }
            }

            return markdownBuilder.ToString();
        }
    }
}
