namespace DndHelper.Infrastructure;

public class Result<TValue, TStatus> : INoValueResult<TStatus>
{
    internal TValue Value { get; set; }
    public bool IsSuccess { get; set; }
    public TStatus Status { get; set; }
    public Exception Exception { get; set; }

    internal Result()
    {

    }

    public bool TryGetValue(out TValue value)
    {
        value = Value;

        if (value == null)
            return false;
        return IsSuccess;
    }
    public bool TryGetValue(out TValue value, out TStatus status)
    {
        value = Value;
        status = Status;

        if (value == null)
            return false;
        return IsSuccess;
    }

    public static implicit operator Result<TValue, TStatus>(TValue value)
    {
        return Result.CreateSuccess<TValue, TStatus>(value);
    }

    public Result<TValue, TStatus> OnFailure(Action doOnFailure)
    {
        if (!IsSuccess)
            doOnFailure();
        return this;
    }

    public Result<TValue, TStatus> OnSuccess(Action doOnSuccess)
    {
        if (IsSuccess)
            doOnSuccess();
        return this;
    }

    public Result<TValue, TStatus> OnFailure(Action<Result<TValue, TStatus>> doOnFailure)
    {
        if (!IsSuccess)
            doOnFailure(this);
        return this;
    }

    public Result<TValue, TStatus> OnSuccess(Action<TValue> doOnSuccess)
    {
        if (IsSuccess)
            doOnSuccess(Value);
        return this;
    }
}