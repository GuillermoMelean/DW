using System;
namespace Results
{
    public class ReasonStringBuilder
    {
        private string reasonType = string.Empty;

        private readonly List<string> infos = new List<string>();

        public ReasonStringBuilder WithReasonType(Type type)
        {
            reasonType = type.Name;
            return this;
        }

        public ReasonStringBuilder WithInfo(string label, string value)
        {
            //string text = value.ToLabelValueStringOrEmpty(label);
            string text = value;
            if (!string.IsNullOrEmpty(text))
            {
                infos.Add(text);
            }

            return this;
        }

        public string Build()
        {
            string text = (infos.Any() ? (" with " + ReasonInfosToString(infos)) : string.Empty);
            return reasonType + text;
        }

        private static string ReasonInfosToString(List<string> reasonInfos)
        {
            return string.Join(", ", reasonInfos);
        }
    }
}

