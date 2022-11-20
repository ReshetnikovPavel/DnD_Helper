﻿using Infrastructure;

namespace Domain;

public class Skill : ValueType<Skill>, IBasedOnAbility<SkillName>
{
	public AbilityScore Ability { get; }
	public bool IsProficient { get; }
	public SkillName Name { get; }
	public int Modifier => Ability.Modifier + (IsProficient ? ProficiencyBonus.Value : 0);
	public ProficiencyBonus ProficiencyBonus { get; }
	
	public Skill(SkillName name, AbilityScore ability, ProficiencyBonus proficiencyBonus)
	{
		Name = name;
		Ability = ability;
		ProficiencyBonus = proficiencyBonus;
	}
}