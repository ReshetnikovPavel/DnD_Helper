using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Initiative : ValueType<Initiative>, IHaveValue, IDndObject
{
    public int Value { get; }
}