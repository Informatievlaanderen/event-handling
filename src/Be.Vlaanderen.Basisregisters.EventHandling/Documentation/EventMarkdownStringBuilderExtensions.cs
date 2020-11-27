namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System.Collections.Generic;
    using System.Text;

    internal static class EventMarkdownStringBuilderExtensions
    {
        public static StringBuilder AppendRegistry(this StringBuilder builder, string registryName)
            => builder
                .AppendLine($"# {registryName}")
                .AppendLine();

        public static StringBuilder AppendInfo(this StringBuilder builder, IEnumerable<EventInformation> eventInfos)
        {
            foreach (var info in eventInfos)
                builder
                    .AppendLine($"## {info.Name}")
                    .AppendLine()
                    .AppendLine(info.Description)
                    .AppendLine()
                    .AppendInfo(info.Properties);

            return builder;
        }

        private static StringBuilder AppendInfo(this StringBuilder builder, IEnumerable<EventPropertyInformation> eventPropertyInfos)
        {
            builder
                .AppendLine("| Attribuut | Omschrijving |")
                .AppendLine("|---|---|");

            foreach (var property in eventPropertyInfos)
                builder.AppendLine($"| {property.Name} | {property.Description} |");

            return builder.AppendLine();
        }
    }
}
