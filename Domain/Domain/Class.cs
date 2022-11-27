using Infrastructure;

namespace Domain;

public class Class : ValueType<Class>, IDndObject
{
    public string Name { get; set; }
    public HitDice HitDice { get; set; }
    public IEnumerable<AbilityName> AbilityNamesForSavingThrows { get; set; }
    public AbilityName? SpellAbility { get; set; }
    public IDictionary<int, IEnumerable<ClassFeature>> LevelFeatures { get; set; }
}
