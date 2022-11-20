using Infrastructure;

namespace Domain;

public class Character : Entity<Guid>
{
	public Character(Guid id) : base(id)
	{
	}
	
	public string Name { get; }
	public string PlayerName { get; }
	public IReadOnlyDictionary<AbilityName, AbilityScore> Abilities { get; }
	public Race Race { get; }
	//public Class Class { get; }
	public IReadOnlyDictionary<SkillName, Skill> Skills { get; }
	public ProficiencyBonus ProficiencyBonus { get; }
	
	
	public Dictionary<AbilityName, AbilityScore> CreateAbilityScores()
	{
		return Enum.GetValues<AbilityName>()
			.ToDictionary(
				abilityName => abilityName,
				abilityName => new AbilityScore(abilityName, 0));
	}
	
	public Dictionary<SkillName, Skill> CreateSkills()
	{
		return null;
	}
}