using Infrastructure;

namespace Domain;

public class ProficiencyBonus : ValueType<ProficiencyBonus>, IHaveValue, IDndObject
{
	public int Value { get; }
}