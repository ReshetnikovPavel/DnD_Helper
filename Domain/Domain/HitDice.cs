using Infrastructure;

namespace Domain;

public class HitDice : ValueType<HitDice>, IDndObject
{
	public Dice Total { get; }
	public (DiceName, AbilityScore) Current { get; }
}