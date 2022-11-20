using Infrastructure;

namespace Domain;

public class Initiative : ValueType<Initiative>, IHaveValue
{
	public int Value { get; }
}