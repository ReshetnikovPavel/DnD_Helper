using Infrastructure;

namespace Domain;

public class SavingThrow : ValueType<SavingThrow>, IDndObject
{
	private AbilityScore Ability { get; }
	private int ProficiencyBonus { get; }
	private int Modifier => Ability.Modifier;
}