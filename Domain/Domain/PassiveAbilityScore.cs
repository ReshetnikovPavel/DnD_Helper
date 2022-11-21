using Infrastructure;

namespace Domain;

public class PassiveSkill : ValueType<PassiveSkill>, IBasedOnAbility<AbilityName>, IDndObject
{
	public AbilityScore Ability { get; }
	public bool IsProficient { get; }
	public AbilityName Name { get; }
	public ProficiencyBonus ProficiencyBonus { get; }
}