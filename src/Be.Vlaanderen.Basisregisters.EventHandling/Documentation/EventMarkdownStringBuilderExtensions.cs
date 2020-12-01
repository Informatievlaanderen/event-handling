namespace Be.Vlaanderen.Basisregisters.EventHandling.Documentation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal static class EventMarkdownStringBuilderExtensions
    {
        public static StringBuilder AppendRegistry(this StringBuilder builder, string registryName)
            => builder
                .AppendLine($"# {registryName}")
                .AppendLine();

        public static StringBuilder AppendInfo(this StringBuilder builder, IEnumerable<EventInformation> eventInfos)
        {
            foreach (var info in eventInfos.Where(i => i != null))
                builder
                    .AppendEventName(info)
                    .AppendEventDescription(info)
                    .AppendProperties(info);

            return builder;
        }

        private static StringBuilder AppendEventName(this StringBuilder builder, EventInformation info)
            => builder
                .AppendLine($"## {info.Name}")
                .AppendLine();

        private static StringBuilder AppendEventDescription(this StringBuilder builder, EventInformation info)
            => string.IsNullOrWhiteSpace(info.Description)
                ? builder
                : builder
                    .AppendLine(info.Description)
                    .AppendLine();

        private static StringBuilder AppendProperties(this StringBuilder builder, EventInformation info)
        {
            builder
                .AppendLine("| Attribuut | Omschrijving |")
                .AppendLine("|---|---|");

            foreach (var property in info.Properties.Where(p => p != null))
                builder.AppendLine($"| {property.Name} | {property.Description} |");

            return builder.AppendLine();
        }
    }
}
