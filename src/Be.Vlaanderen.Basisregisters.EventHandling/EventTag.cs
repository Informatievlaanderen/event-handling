namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;

    public sealed class EventTag
    {
        public static class For
        {
            public const string Sync = "sync";
            public const string Crab = "crab";
            public const string Edit = "edit";
            public const string Merger = "merger";
            public const string Legacy = "legacy";

            public const string Municipality = "municipality";
            public const string PostalInformation = "postalinformation";
            public const string StreetName = "streetname";
            public const string Address = "address";
            public const string Building = "building";
            public const string Parcel = "parcel";
        }

        private readonly string _tagType;

        private EventTag(string tagType)
            => _tagType = string.IsNullOrWhiteSpace(tagType)
                ? throw new ArgumentNullException(nameof(tagType))
                : tagType.ToLowerInvariant();

        public static EventTag Create(string tagType)
            => new EventTag(tagType);

        public override string ToString() => _tagType;

        public override bool Equals(object? obj)
            => obj is EventTag tag && Equals(tag);

        private bool Equals(EventTag other)
            => _tagType == other._tagType;

        public override int GetHashCode()
            => _tagType.GetHashCode();
    }
}
