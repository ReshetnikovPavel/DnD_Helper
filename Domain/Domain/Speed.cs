using Infrastructure;

namespace Domain;

public class Speed : ValueType<Speed>, IHaveValue, IDndObject
{
	public Speed(int value)
	{
		Value = value;
	}
	public int Value { get; }
}