using Infrastructure;

namespace Domain;

public class HitDice : ValueType<HitDice>
{
	public Dice Total { get; }
	public (DiceName, AbilityScore) Current { get; }
}