using Infrastructure;

namespace Domain;

public class Trait : ValueType<Trait>, IDndObject
{
	public string Name { get; }
	public string Description { get; }
}