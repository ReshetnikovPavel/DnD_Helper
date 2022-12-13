using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class DeathSaves : ValueType<DeathSaves>, IDndObject
{
	public int Successes { get; set; }
	public int Failures { get; set; }
}