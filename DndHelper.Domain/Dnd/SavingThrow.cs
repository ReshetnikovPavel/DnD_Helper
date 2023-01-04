using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class SavingThrow : ValueType<SavingThrow>, IDndObject
{
	public AbilityScore Ability { get; }
	public ProficiencyBonus ProficiencyBonus { get; }

    public bool IsProficient { get; set; }
    public int Modifier => Ability.Modifier;

    public SavingThrow(AbilityScore ability, ProficiencyBonus proficiencyBonus)
    {
        Ability = ability;
        ProficiencyBonus = proficiencyBonus;
    }
}