using System;
namespace Results
{
    public class Success : Reason
    {
        public Success(string message)
        {
            base.Message = message;
        }

        public Success WithMetadata(string metadataName, object metadataValue)
        {
            base.Metadata.Add(metadataName, metadataValue);
            return this;
        }

        public Success WithMetadata(Dictionary<string, object> metadata)
        {
            foreach (KeyValuePair<string, object> metadatum in metadata)
            {
                base.Metadata.Add(metadatum.Key, metadatum.Value);
            }

            return this;
        }
    }
}

