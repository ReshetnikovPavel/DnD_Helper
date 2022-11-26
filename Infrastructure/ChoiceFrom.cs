namespace Infrastructure;

public class ChooseMany<T> : ValueType<ChooseMany<T>> 
{
    public IEnumerable<T> Options { get; }
    public int HowManyToChoose { get; }

    public ChooseMany(IEnumerable<T> options, int howManyToChoose)
    {
        Options = options;
        HowManyToChoose = howManyToChoose;
    }
}