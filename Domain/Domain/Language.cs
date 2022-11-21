using Infrastructure;

namespace Domain;

public class Language : ValueType<Language>, IDndObject
{
	public Language(string name)
	{
		Name = name;
	}
	public string Name { get; }
}