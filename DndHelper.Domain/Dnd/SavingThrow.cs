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

    public static IReadOnlyDictionary<AbilityName, SavingThrow> CreateFrom(
        IReadOnlyDictionary<AbilityName, AbilityScore> abilities, ProficiencyBonus proficiencyBonus)
    {
        var savingThrows = new Dictionary<AbilityName, SavingThrow>();
        foreach (var (abilityName, ability) in abilities)
            savingThrows[abilityName] = new SavingThrow(ability, proficiencyBonus);
        return savingThrows;
    }
}