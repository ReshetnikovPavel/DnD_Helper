namespace DndHelper.Infrastructure;

public static class Result
{

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

    public static Result<TValue, TStatus> CreateFailure<TValue, TStatus>(TStatus status, Exception exception)
    {
        return new Result<TValue, TStatus>
        {
            IsSuccess = false,
            Status = status,
            Exception = exception
        };
    }

    public static Result<TStatus> CreateSuccess<TStatus>()
    {
        return new Result<TStatus>
        {
            IsSuccess = true
        };
    }

    public static Result<TStatus> CreateFailure<TStatus>(TStatus status)
    {
        return new Result<TStatus>
        {
            IsSuccess = false,
            Status = status
        };
    }

    public static Result<TStatus> CreateFailure<TStatus>(TStatus status, Exception exception)
    {
        return new Result<TStatus>
        {
            IsSuccess = false,
            Status = status,
            Exception = exception
        };
    }
}