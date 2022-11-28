using Infrastructure;

namespace Domain;

public class ProficiencyBonus : ValueType<ProficiencyBonus>, IHaveValue, IDndObject
{
    public ProficiencyBonus(int value)
    {
        Value = value;
    }
	public int Value { get; }
}