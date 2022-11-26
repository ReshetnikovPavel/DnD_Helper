using Infrastructure;

namespace Domain;

public class Class : ValueType<Class>, IDndObject
{
    public string Name { get; set; }
    public HitDice HitDice { get; set; }
    public IEnumerable<SavingThrow> SavingThrow { get; set; }
    public AbilityName SpellAbility { get; set; }


}