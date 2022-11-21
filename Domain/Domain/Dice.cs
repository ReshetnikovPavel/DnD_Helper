using Infrastructure;

namespace Domain;

public class Dice : ValueType<Dice>
{
	public int Quantity { get; }
	public DiceName Sides { get; }
	public override string ToString() => $"{Quantity}d{Sides}";

    public Dice(int quantity, DiceName sides)
    {
        Quantity = quantity;
        Sides = sides;
    }

    public int[] GetRandomValues()
    {
        var casts = new List<int>();
        var random = new Random();
        for (int i = 0; i < Quantity; i++)
        {
            var value = random.Next(1, (int)Sides + 1);
            casts.Add(value);
        }
        return casts.ToArray();
    }
}