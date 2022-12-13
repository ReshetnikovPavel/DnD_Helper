using Infrastructure;

namespace DndHelper.Domain.Dnd;
public class RandomAbilityScoreDistibutor
{
    public IEnumerable<int> GetRandomAbilityScoresValues()
    {
        var values = new List<int>();
        var abilityCount = Enum.GetNames(typeof(AbilityName)).Length;
        for (var i = 0; i < abilityCount; i++)
            values.Add(GetRandomValueAbility());

        return values;
    }

    private int GetRandomValueAbility()
    {
        var dice = new Dice(4, DiceName.D6);
        var values = dice.GetRandomValues().ToList();
        values.Remove(values.Min());

        return values.Sum();
    }
}
