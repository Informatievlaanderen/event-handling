namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class RegistryEventsMarkdownGeneratorCollectionExtensions
    {
        public static string Generate(this IEnumerable<IRegistryEventsMarkdownGenerator> markdownGenerators)
            => markdownGenerators.ExecuteOnAll(generator => generator.Generate());

        public static string GenerateFor(
            this IEnumerable<IRegistryEventsMarkdownGenerator> markdownGenerators,
            IEnumerable<EventTag> tags)
        {
            var tagsList = tags.ToList();
            return markdownGenerators.ExecuteOnAll(generator => generator.GenerateFor(tagsList));
        }

        private static string ExecuteOnAll(this IEnumerable<IRegistryEventsMarkdownGenerator> markdownGenerators, Action<IRegistryEventsMarkdownGenerator> executeUsing)
        {
            var markdownBuilder = new StringBuilder();
            using (var generators = markdownGenerators.GetEnumerator())
            {
                var next = generators.MoveNext();
                while (next)
                {
                    var generator = generators
                        .Current
                        ?.CreateDuplicateUsing(markdownBuilder);

                    if (generator != null)
                        executeUsing(generator);

                    next = generators.MoveNext();
                    if (next && generator != null)
                        markdownBuilder.AppendLine();
                }
            }

            return markdownBuilder.ToString();
        }
    }
}
