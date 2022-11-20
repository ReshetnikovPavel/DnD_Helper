using Infrastructure;

namespace Domain;

public class ProficiencyBonus : ValueType<ProficiencyBonus>, IHaveValue
{
	public int Value { get; }
}