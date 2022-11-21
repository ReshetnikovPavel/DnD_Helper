using Infrastructure;

namespace Domain;

public class Initiative : ValueType<Initiative>, IHaveValue, IDndObject
{
	public int Value { get; }
}