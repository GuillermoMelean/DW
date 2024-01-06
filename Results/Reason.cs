using System;
namespace Results
{
    public class Reason
    {
        public string Message { get; protected set; }

        public Dictionary<string, object> Metadata { get; protected set; }

        protected Reason()
        {
            Metadata = new Dictionary<string, object>();
        }

        public bool HasMetadataKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            return Metadata.ContainsKey(key);
        }

        public bool HasMetadata(string key, Func<object, bool> predicate)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            if (Metadata.TryGetValue(key, out var value))
            {
                return predicate(value);
            }

            return false;
        }

        protected virtual ReasonStringBuilder GetReasonStringBuilder()
        {
            return new ReasonStringBuilder().WithReasonType(GetType()).WithInfo("Message", Message).WithInfo("Metadata", string.Join("; ", Metadata));
        }

        public override string ToString()
        {
            return GetReasonStringBuilder().Build();
        }
    }
}

