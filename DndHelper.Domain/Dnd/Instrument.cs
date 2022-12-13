using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Instrument : ValueType<Instrument>, IDndObject
{
	public Instrument(string name)
	{
		Name = name;
	}

	public string Name { get; }
	public string Description { get; }
}