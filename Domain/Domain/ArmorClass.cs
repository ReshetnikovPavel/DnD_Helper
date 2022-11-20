using Infrastructure;

namespace Domain;

public class ArmorClass : ValueType<ArmorClass>, IHaveValue
{
	public int Value { get; }
}