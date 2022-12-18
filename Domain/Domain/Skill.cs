using Infrastructure;

namespace Domain;

public class Skill : ValueType<Skill>, IBasedOnAbility<SkillName>, IDndObject
{
	public AbilityScore Ability { get; }
	public bool IsProficient { get; set; }
	public SkillName Name { get; }
	public int Modifier => Ability.Modifier + (IsProficient ? ProficiencyBonus.Value : 0);
	public ProficiencyBonus ProficiencyBonus { get; }
	
	public Skill(SkillName name, AbilityScore ability, ProficiencyBonus proficiencyBonus)
	{
		Name = name;
		Ability = ability;
		ProficiencyBonus = proficiencyBonus;
	}

    public static IReadOnlyDictionary<SkillName, Skill> CreateFrom(IReadOnlyDictionary<AbilityName, AbilityScore> scores, ProficiencyBonus proficiencyBonus)
    {
		var skills = new Dictionary<SkillName, Skill>();
        foreach (var skillName in Enum.GetValues<SkillName>())
        {
            var abilityName = AbilityScore.GetNameFromSkillName(skillName);
            skills[skillName] = new Skill(skillName, scores[abilityName], proficiencyBonus);
        }
		return skills;
    }
}