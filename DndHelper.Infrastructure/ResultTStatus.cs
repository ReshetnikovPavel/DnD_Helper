namespace DndHelper.Infrastructure;

public class Result<TStatus> : INoValueResult<TStatus>
{
    public bool IsSuccess { get; set; }
    public TStatus Status { get; set; }
    public Exception Exception { get; set; }

    internal Result()
    {

    }

    public Result<TValue, TStatus> ToResultWithValue<TValue>(TValue value)
    {
        return new Result<TValue, TStatus>()
        {
            IsSuccess = IsSuccess,
            Status = Status,
            Exception = Exception,
            Value = value
        };
    }

    public Result<TStatus> OnFailure(Action doOnFailure)
    {
        if (!IsSuccess)
            doOnFailure();
        return this;
    }

    public Result<TStatus> OnSuccess(Action doOnSuccess)
    {
        if (IsSuccess)
            doOnSuccess();
        return this;
    }

    public Result<TStatus> OnFailure(Action<Result<TStatus>> doOnFailure)
    {
        if (!IsSuccess)
            doOnFailure(this);
        return this;
    }

    public Result<TStatus> OnSuccess(Action<Result<TStatus>> doOnSuccess)
    {
        if (IsSuccess)
            doOnSuccess(this);
        return this;
    }
}