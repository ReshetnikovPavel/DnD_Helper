namespace Domain;

public class Armor : IDndObject
{
	public Armor(string name)
	{
		Name = name;
	}
	public string Name { get; }
}