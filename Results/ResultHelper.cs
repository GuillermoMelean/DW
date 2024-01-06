using System;
namespace Results
{
    internal static class ResultHelper
    {
        public static Result Merge(params ResultBase[] results)
        {
            Result result = Result.Ok();
            for (int i = 0; i < results.Length; i++)
            {
                foreach (Reason reason in results[i].Reasons)
                {
                    result.WithReason(reason);
                }
            }

            return result;
        }

        public static Result<IEnumerable<TValue>> MergeWithValue<TValue>(params Result<TValue>[] results)
        {
            Result<IEnumerable<TValue>> result = Result.Ok((IEnumerable<TValue>)new List<TValue>());
            for (int i = 0; i < results.Length; i++)
            {
                foreach (Reason reason in results[i].Reasons)
                {
                    result.WithReason(reason);
                }
            }

            if (result.IsSuccess)
            {
                result.WithValue(results.Select((Result<TValue> r) => r.Value).ToList());
            }

            return result;
        }

        public static bool HasError<TError>(List<Error> errors, Func<TError, bool> predicate) where TError : Error
        {
            if (errors.Any(delegate (Error error)
            {
                TError val = error as TError;
                return val != null && predicate(val);
            }))
            {
                return true;
            }

            foreach (Error error in errors)
            {
                if (HasError(error.Reasons, predicate))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasSuccess<TSuccess>(List<Success> successes, Func<TSuccess, bool> predicate) where TSuccess : Success
        {
            return successes.Any(delegate (Success success)
            {
                TSuccess val = success as TSuccess;
                return val != null && predicate(val);
            });
        }
    }
}

