using System;

namespace Results
{
    internal class ReasonFormat
    {
        public static string ErrorReasonsToString(List<Error> errorReasons)
        {
            return string.Join("; ", errorReasons);
        }

        public static string ReasonsToString(List<Reason> errorReasons)
        {
            return string.Join("; ", errorReasons);
        }
    }
}

