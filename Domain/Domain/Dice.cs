using Infrastructure;

namespace Domain;

public class Dice : ValueType<Dice>, IDndObject
{
	public int Quantity { get; }
	public DiceName Sides { get; }
	public override string ToString() => $"{Quantity}{Sides}";

    public Dice(int quantity, DiceName sides)
    {
        Quantity = quantity;
        Sides = sides;
    }

    public IEnumerable<int> GetRandomValues()
    {
        var random = new Random();
        return Enumerable.Range(1, Quantity).Select(_ => random.Next(1, (int)Sides + 1));
    }
}