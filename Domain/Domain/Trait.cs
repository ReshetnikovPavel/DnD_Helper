using Infrastructure;

namespace Domain;

public class Trait : ValueType<Trait>
{
	public string Name { get; }
	public string Description { get; }
}