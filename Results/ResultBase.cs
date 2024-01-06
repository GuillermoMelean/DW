using System;

namespace Results
{
	public abstract class ResultBase<TResult> : ResultBase where TResult : ResultBase<TResult>
	{
        public TResult WithReason(Reason reason)
        {
            base.Reasons.Add(reason);
            return (TResult)this;
        }

        public TResult WithReasons(IEnumerable<Reason> reasons)
        {
            base.Reasons.AddRange(reasons);
            return (TResult)this;
        }

        public TResult WithError(string errorMessage)
        {
            return WithError(new Error(errorMessage));
        }

        public TResult WithError(Error error)
        {
            return WithReason(error);
        }

        public TResult WithErrors(IEnumerable<Error> errors)
        {
            return WithReasons(errors);
        }

        public TResult WithErrors(IEnumerable<string> errors)
        {
            return WithReasons(errors.Select((string errorMessage) => new Error(errorMessage)));
        }

        public TResult WithError<TError>() where TError : Error, new()
        {
            return WithError(new TError());
        }

        public TResult WithSuccess(string successMessage)
        {
            return WithSuccess(new Success(successMessage));
        }

        public TResult WithSuccess(Success success)
        {
            return WithReason(success);
        }

        public TResult WithSuccess<TSuccess>() where TSuccess : Success, new()
        {
            return WithSuccess(new TSuccess());
        }

        public TResult Log()
        {
            return Log(string.Empty);
        }

        public TResult Log(string context)
        {
            Result.Settings.Logger.Log(context, this);
            return (TResult)this;
        }

        public override string ToString()
        {
            string arg = (base.Reasons.Any() ? (", Reasons='" + ReasonFormat.ReasonsToString(base.Reasons) + "'") : string.Empty);
            return $"Result: IsSuccess='{base.IsSuccess}'{arg}";
        }
    }

    public abstract class ResultBase
    {
        public bool IsFailed => Reasons.OfType<Error>().Any();

        public bool IsSuccess => !IsFailed;

        public List<Reason> Reasons { get; }

        public List<Error> Errors => Reasons.OfType<Error>().ToList();

        public List<Success> Successes => Reasons.OfType<Success>().ToList();

        protected ResultBase()
        {
            Reasons = new List<Reason>();
        }

        public bool HasError<TError>() where TError : Error
        {
            return HasError((TError error) => true);
        }

        public bool HasError<TError>(Func<TError, bool> predicate) where TError : Error
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return ResultHelper.HasError(Errors, predicate);
        }

        public bool HasError(Func<Error, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return ResultHelper.HasError(Errors, predicate);
        }

        public bool HasSuccess<TSuccess>() where TSuccess : Success
        {
            return HasSuccess((TSuccess success) => true);
        }

        public bool HasSuccess<TSuccess>(Func<TSuccess, bool> predicate) where TSuccess : Success
        {
            return ResultHelper.HasSuccess(Successes, predicate);
        }

        public bool HasSuccess(Func<Success, bool> predicate)
        {
            return ResultHelper.HasSuccess(Successes, predicate);
        }
    }
}

