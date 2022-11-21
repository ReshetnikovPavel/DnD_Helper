using Infrastructure;

namespace Domain;

public class HitPoints : ValueType<HitDice>, IDndObject
{
	public int Current { get; }
	public int Maximum { get; }
	public int Temporary { get; }
}