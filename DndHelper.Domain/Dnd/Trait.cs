using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Trait : ValueType<Trait>, IDndObject
{
    public string Name { get; }
    public string Description { get; }
}