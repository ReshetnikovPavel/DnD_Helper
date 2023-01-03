using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Spell : ValueType<Spell>, IDndObject
{
	public Spell(string name, int level, IEnumerable<SpellComponent> components, string school, string time, IEnumerable<string> classNames)
	{
		Name = name;
		Level = level;
		Components = components;
		School = school;
        Time = time;
		ClassNames = classNames;
    }
	public string Name { get; }
	public int Level { get; }
	public IEnumerable<SpellComponent> Components { get; }
	public string StringComponents => string.Join("", Components.Select(c => c.ToString()[0]));
	public string School { get; }
	public string Description { get; }
	public string Time { get; }
	public IEnumerable<string> ClassNames { get; }
}