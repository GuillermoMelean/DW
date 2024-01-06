
namespace Results
{
    public class Error : Reason
    {
        public List<Error> Reasons { get; }

        public Error()
        {
            Reasons = new List<Error>();
        }

        public Error(string message)
            : this()
        {
            base.Message = message;
        }

        public Error(string message, Error causedBy)
            : this(message)
        {
            Reasons.Add(causedBy);
        }

        public Error CausedBy(Error error)
        {
            Reasons.Add(error);
            return this;
        }

        public Error CausedBy(Exception exception)
        {
            Reasons.Add(new ExceptionalError(exception));
            return this;
        }

        public Error CausedBy(string message, Exception exception)
        {
            Reasons.Add(new ExceptionalError(message, exception));
            return this;
        }

        public Error CausedBy(string message)
        {
            Reasons.Add(new Error(message));
            return this;
        }

        public Error CausedBy(IEnumerable<Error> errors)
        {
            Reasons.AddRange(errors);
            return this;
        }

        public Error CausedBy(IEnumerable<string> errors)
        {
            Reasons.AddRange(errors.Select((string errorMessage) => new Error(errorMessage)));
            return this;
        }

        public Error WithMessage(string message)
        {
            base.Message = message;
            return this;
        }

        public Error WithMetadata(string metadataName, object metadataValue)
        {
            base.Metadata.Add(metadataName, metadataValue);
            return this;
        }

        public Error WithMetadata(Dictionary<string, object> metadata)
        {
            foreach (KeyValuePair<string, object> metadatum in metadata)
            {
                base.Metadata.Add(metadatum.Key, metadatum.Value);
            }

            return this;
        }

        protected override ReasonStringBuilder GetReasonStringBuilder()
        {
            return base.GetReasonStringBuilder().WithInfo("Reasons", ReasonFormat.ErrorReasonsToString(Reasons));
        }
    }
}

