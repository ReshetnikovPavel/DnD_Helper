using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Feat : ValueType<Feat>, IDndObject
{
    public Feat(string name)
    {
        Name = name;
    }

    public string Name { get; }
	public string Description { get; }
}