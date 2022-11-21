using Infrastructure;

namespace Domain;

public class Dice : ValueType<Dice>, IDndObject
{
	public int Quantity { get; }
	public DiceName Sides { get; }
	public override string ToString() => $"{Quantity}d{Sides}";
}