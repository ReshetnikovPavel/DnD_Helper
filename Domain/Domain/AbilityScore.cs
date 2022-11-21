using Infrastructure;

namespace Domain;

public class AbilityScore : ValueType<AbilityScore>, IHaveValue
{
	public AbilityName Name { get; }
	public int Value { get; set; }
	public int Modifier => (Value - 10).DivideBy(2);

	public AbilityScore(AbilityName name, int value)
	{
		Name = name;
		Value = value;
	}

    public void IncreaseValue()
    {
        if (Value < 20)
            Value++;
    }

    public void DecreaseValue()
    {
        if (Value > 1)
            Value--;
    }
}