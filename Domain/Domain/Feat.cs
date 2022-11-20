using Infrastructure;

namespace Domain;

public class Feat : ValueType<Feat>
{
	public string Name { get; }
	public string Description { get; }
}