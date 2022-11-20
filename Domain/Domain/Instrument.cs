using Infrastructure;

namespace Domain;

public class Instrument : ValueType<Instrument>
{
	public Instrument(string name)
	{
		Name = name;
	}

	public string Name { get; }
	public string Description { get; }
}