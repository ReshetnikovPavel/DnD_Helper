namespace DndHelper.Infrastructure;

public class Result<TValue, TStatus>
{
    public TValue Value { get; set; }
    public bool IsSuccess { get; set; }
    public TStatus Status { get; set; }

    internal Result()
    {

    }

    public bool TryGetValue(out TValue value)
    {
        value = Value;
        return IsSuccess;
    }
    public bool TryGetValue(out TValue value, out TStatus status)
    {
        value = Value;
        status = Status;
        return IsSuccess;
    }

    public static implicit operator Result<TValue, TStatus>(TValue value)
    {
        return Result.CreateSuccess<TValue, TStatus>(value);
    }
}

public static class Result
{
    public static Result<TValue, TStatus> CreateSuccess<TValue, TStatus>()
    {
        return new Result<TValue, TStatus>
        {
            IsSuccess = true
        };
    }

    public static Result<TValue, TStatus> CreateSuccess<TValue, TStatus>(TValue value)
    {
        return new Result<TValue, TStatus>
        {
            IsSuccess = true,
            Value = value
        };
    }

    public static Result<TValue, TStatus> CreateFailure<TValue, TStatus>(TStatus status)
    {
        return new Result<TValue, TStatus>
        {
            IsSuccess = false,
            Status = status
        };
    }
}