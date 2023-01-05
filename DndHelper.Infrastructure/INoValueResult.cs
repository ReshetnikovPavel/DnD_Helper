namespace DndHelper.Infrastructure;

public interface INoValueResult<TStatus>
{
    public bool IsSuccess { get; set; }
    public TStatus Status { get; set; }
    public Exception Exception { get; set; }
}