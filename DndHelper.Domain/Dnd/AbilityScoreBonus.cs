using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class AbilityScoreBonus : ValueType<AbilityScoreBonus>, IDndObject
{
    public AbilityScoreBonus(AbilityName name, int value)
    {
        Name = name;
        Value = value;
    }

    public AbilityName Name { get; }
    public int Value { get; }
}