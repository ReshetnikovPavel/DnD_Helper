namespace Infrastructure;

public class ChooseRelational<T1, T2> : ValueType<ChooseRelational<T1, T2>>
{
    public IEnumerable<T1> Options { get; init; }
    public T2 Value { get; init; }
}