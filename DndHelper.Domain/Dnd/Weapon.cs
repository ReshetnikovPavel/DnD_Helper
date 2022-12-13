using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Weapon : ValueType<Weapon>, IDndObject
{
	public Weapon(string name)
	{
		Name = name;
	}
	public string Name { get; }
	public string Description { get; }
}