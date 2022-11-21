using Infrastructure;

namespace Domain;

public class AbilityScore : ValueType<AbilityScore>, IHaveValue, IDndObject
{
	public AbilityName Name { get; }
	public int Value { get; }
	public int Modifier => (Value - 10).DivideBy(2);

	public AbilityScore(AbilityName name, int value)
	{
		Name = name;
		Value = value;
	}
}