using Infrastructure;

namespace Domain;

public class HitDice : ValueType<HitDice>, IDndObject
{
	public Dice Total { get; }

	public HitDice(Dice total)
    {
        Total = total;
    }
}