using Infrastructure;

namespace Domain;

public class HitPoints : ValueType<HitDice>
{
	public int Current { get; }
	public int Maximum { get; }
	public int Temporary { get; }
}