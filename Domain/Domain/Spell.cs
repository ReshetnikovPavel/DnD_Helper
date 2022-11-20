using Infrastructure;

namespace Domain;

public class Spell : ValueType<Spell>
{
	public Spell(string name, int level)
	{
		Name = name;
		Level = level;
	}
	public string Name { get; }
	public int Level { get; }
	public SpellComponent[] Components { get; }
	public SpellSchool School { get; }
	public string Description { get; }
}