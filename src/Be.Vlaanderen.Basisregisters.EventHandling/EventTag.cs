namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;

    public class EventTag
    {
        public class For
        {
            public const string Sync = "sync";
            public const string Crab = "crab";
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

        protected bool Equals(EventTag other)
            => _tagType == other._tagType;

        public override int GetHashCode()
            => _tagType.GetHashCode();
    }
}
