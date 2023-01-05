namespace DndHelper.Infrastructure;

public class Result<TStatus>
{
    public bool IsSuccess { get; set; }
    public TStatus Status { get; set; }
    public Exception Exception { get; set; }

    internal Result()
    {

    }
}