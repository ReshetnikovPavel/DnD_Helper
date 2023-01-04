namespace DndHelper.Domain.Dnd;

public interface IBasedOnAbility<TNameEnum>
    where TNameEnum : struct, IConvertible
{
    public int Modifier
    {
        get
        {
            var result = Ability.Modifier;
            if (IsProficient)
                result += ProficiencyBonus.Value;
            return result;
        }
    }
    public AbilityScore Ability { get; }
    public bool IsProficient { get; }

    public TNameEnum Name { get; }
    public ProficiencyBonus ProficiencyBonus { get; }
}