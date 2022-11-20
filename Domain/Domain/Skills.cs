using Infrastructure;

namespace Domain;

public class Skills : ValueType<Skills>
{
	public Skill Acrobatics { get; }
	public Skill AnimalHandling { get; }
	public Skill Arcana { get; }
	public Skill Athletics { get; }
	public Skill Deception { get; }
	public Skill History { get; }
	public Skill Insight { get; }
	public Skill Intimidation { get; }
	public Skill Investigation { get; }
	public Skill Medicine { get; }
	public Skill Nature { get; }
	public Skill Perception { get; }
	public Skill Performance { get; }
	public Skill Persuasion { get; }
	public Skill Religion { get; }
	public Skill SleightOfHand { get; }
	public Skill Stealth { get; }
	public Skill Survival { get; }
}