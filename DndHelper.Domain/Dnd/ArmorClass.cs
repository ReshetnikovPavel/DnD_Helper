using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class ArmorClass : ValueType<ArmorClass>, IHaveValue, IDndObject
{
	public int Value { get; }
}