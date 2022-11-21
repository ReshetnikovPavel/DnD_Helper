using Infrastructure;

namespace Domain;

public class ArmorClass : ValueType<ArmorClass>, IHaveValue, IDndObject
{
	public int Value { get; }
}