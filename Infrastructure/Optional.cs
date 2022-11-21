namespace Infrastructure;

public class Optional<T> : ValueType<Optional<T>> 
{
    public IEnumerable<T> Options { get; }
    public int HowManyToChoose { get; }

    public Optional(IEnumerable<T> options, int howManyToChoose)
    {
        Options = options;
        HowManyToChoose = howManyToChoose;
    }
}