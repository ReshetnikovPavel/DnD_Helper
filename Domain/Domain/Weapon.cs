using Infrastructure;

namespace Domain;

public class Weapon : ValueType<Weapon>
{
	public Weapon(string name)
	{
		Name = name;
	}
	public string Name { get; }
	public string Description { get; }
}