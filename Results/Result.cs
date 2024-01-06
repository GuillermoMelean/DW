namespace Results;

public class Result: ResultBase<Result>
{
    internal static ResultSettings Settings { get; private set; }

    static Result()
    {
        Settings = new ResultSettingsBuilder().Build();
    }

    public static void Setup(Action<ResultSettingsBuilder> setupFunc)
    {
        ResultSettingsBuilder resultSettingsBuilder = new ResultSettingsBuilder();
        setupFunc(resultSettingsBuilder);
        Settings = resultSettingsBuilder.Build();
    }

    public static Result Ok()
    {
        return new Result();
    }

    public static Result Fail(Error error)
    {
        Result result = new Result();
        result.WithError(error);
        return result;
    }

    public static Result Fail(IEnumerable<Error> errors)
    {
        Result result = new Result();
        result.WithErrors(errors);
        return result;
    }

    public static Result Fail(string errorMessage)
    {
        Result result = new Result();
        result.WithError(new Error(errorMessage));
        return result;
    }

    public static Result<TValue> Ok<TValue>(TValue value)
    {
        Result<TValue> result = new Result<TValue>();
        result.WithValue(value);
        return result;
    }

    public static Result<TValue> Fail<TValue>(Error error)
    {
        Result<TValue> result = new Result<TValue>();
        result.WithError(error);
        return result;
    }

    public static Result<TValue> Fail<TValue>(string errorMessage)
    {
        Result<TValue> result = new Result<TValue>();
        result.WithError(new Error(errorMessage));
        return result;
    }

    public static Result Merge(params ResultBase[] results)
    {
        return ResultHelper.Merge(results);
    }

    public static Result<IEnumerable<TValue>> Merge<TValue>(params Result<TValue>[] results)
    {
        return ResultHelper.MergeWithValue(results);
    }

    public static Result OkIf(bool isSuccess, Error error)
    {
        if (!isSuccess)
        {
            return Fail(error);
        }

        return Ok();
    }

    public static Result OkIf(bool isSuccess, string error)
    {
        if (!isSuccess)
        {
            return Fail(error);
        }

        return Ok();
    }

    public static Result FailIf(bool isFailure, Error error)
    {
        if (!isFailure)
        {
            return Ok();
        }

        return Fail(error);
    }

    public static Result FailIf(bool isFailure, string error)
    {
        if (!isFailure)
        {
            return Ok();
        }

        return Fail(error);
    }

    public static Result Try(Action action, Func<Exception, Error> catchHandler = null)
    {
        catchHandler = catchHandler ?? Settings.DefaultTryCatchHandler;
        try
        {
            action();
            return Ok();
        }
        catch (Exception arg)
        {
            return Fail(catchHandler(arg));
        }
    }

    public static async Task<Result> Try(Func<Task> action, Func<Exception, Error> catchHandler = null)
    {
        catchHandler = catchHandler ?? Settings.DefaultTryCatchHandler;
        try
        {
            await action();
            return Ok();
        }
        catch (Exception arg)
        {
            return Fail(catchHandler(arg));
        }
    }

    public static Result<T> Try<T>(Func<T> action, Func<Exception, Error> catchHandler = null)
    {
        //catchHandler = catchHandler ?? Settings.DefaultTryCatchHandler;
        try
        {
            return Ok(action());
        }
        catch (Exception arg)
        {
            return Fail(catchHandler(arg));
        }
    }

    public static async Task<Result<T>> Try<T>(Func<Task<T>> action, Func<Exception, Error> catchHandler = null)
    {
        //catchHandler = catchHandler ?? Settings.DefaultTryCatchHandler;
        try
        {
            return Ok(await action());
        }
        catch (Exception arg)
        {
            return Fail(catchHandler(arg));
        }
    }

    public Result<TNewValue> ToResult<TNewValue>()
    {
        return new Result<TNewValue>().WithReasons(base.Reasons);
    }
}

public class Result<TValue> : ResultBase<Result<TValue>>
{
    private TValue _value;

    public TValue ValueOrDefault => _value;

    public TValue Value
    {
        get
        {
            if (base.IsFailed)
            {
                throw new InvalidOperationException("Result is in status failed. Value is not set.");
            }

            return _value;
        }
        private set
        {
            if (base.IsFailed)
            {
                throw new InvalidOperationException("Result is in status failed. Value is not set.");
            }

            _value = value;
        }
    }

    public Result<TValue> WithValue(TValue value)
    {
        Value = value;
        return this;
    }

    public Result ToResult()
    {
        return new Result().WithReasons(base.Reasons);
    }

    public Result<TNewValue> ToResult<TNewValue>(Func<TValue, TNewValue> valueConverter = null)
    {
        if (base.IsSuccess && valueConverter == null)
        {
            throw new ArgumentException("If result is success then valueConverter should not be null");
        }

        return new Result<TNewValue>().WithValue(base.IsFailed ? default(TNewValue) : valueConverter(Value)).WithReasons(base.Reasons);
    }

    public override string ToString()
    {
        string text = base.ToString();
        string text2 = ValueOrDefault?.ToString();
        return text + ", " + text2;
    }

    public static implicit operator Result<TValue>(Result result)
    {
        return result.ToResult<TValue>();
    }

    public static implicit operator Result(Result<TValue> result)
    {
        return result.ToResult();
    }
}