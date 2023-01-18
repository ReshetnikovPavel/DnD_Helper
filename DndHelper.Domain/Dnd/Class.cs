using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Class : ValueType<Class>, IDndObject
{
    public string Name { get; set; }
    public HitDice HitDice { get; set; }
    public IEnumerable<AbilityName> AbilityNamesForSavingThrows { get; set; }
    public AbilityName? SpellAbility { get; set; }
    public IList<IList<ClassFeature>> LevelFeatures { get; set; }
    public SpellSlotsTable SpellSlotsTable { get; set; }
}
