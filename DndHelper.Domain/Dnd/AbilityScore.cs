using DndHelper.Infrastructure;
using DndHelper.Domain.Extensions;

namespace DndHelper.Domain.Dnd;

public class AbilityScore : ValueType<AbilityScore>, IHaveValue, IDndObject
{
	public AbilityName Name { get; }
	public int Value { get; set; }
	public int Modifier => (Value - 10).DivideBy(2);

	public AbilityScore(AbilityName name, int value)
	{
		Name = name;
		Value = value;
	}

    public void IncreaseValue()
    {
        if (CanAdd())
            Value++;
    }

    public void DecreaseValue()
    {
        if (CanDecrease())
            Value--;
    }

    private bool CanAdd() => Value < 20;

    private bool CanDecrease() => Value > 1;

    public void AddBonus(AbilityScoreBonus bonus)
    {
        if (CanAdd() && bonus.Value >= 0 || CanDecrease() && bonus.Value < 0)
            Value += bonus.Value;
    }

    public static Dictionary<AbilityName, AbilityScore> Create()
    {
        return Enum.GetValues<AbilityName>()
            .ToDictionary(
                abilityName => abilityName,
                abilityName => new AbilityScore(abilityName, 0));
    }

    public static AbilityName GetNameFromSkillName(SkillName skillName)
    {
        switch (skillName)
        {
            case SkillName.Athletics:
                return AbilityName.Strength;

            case SkillName.Acrobatics:
            case SkillName.SleightOfHand:
            case SkillName.Stealth:
                return AbilityName.Dexterity;

            case SkillName.Arcana:
            case SkillName.History:
            case SkillName.Investigation:
            case SkillName.Nature:
            case SkillName.Religion:
                return AbilityName.Intelligence;

            case SkillName.AnimalHandling:
            case SkillName.Insight:
            case SkillName.Medicine:
            case SkillName.Perception:
            case SkillName.Survival:
                return AbilityName.Wisdom;

            case SkillName.Deception:
            case SkillName.Intimidation:
            case SkillName.Performance:
            case SkillName.Persuasion:
                return AbilityName.Charisma;

            default:
                throw new ArgumentOutOfRangeException(nameof(skillName), skillName, null);
        }
    }
}