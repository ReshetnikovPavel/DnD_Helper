using Infrastructure;

namespace Domain;

public class RaceOptionals
{
    public IEnumerable<ChooseRelational<AbilityName, int>> AbilityScoreBonuses { get; init; }
    public ChooseMany<Language> Languages { get; init; }
    public ChooseMany<Spell> Spells { get; init; }
    public ChooseMany<Weapon> WeaponsProficiencies { get; init; }
    public ChooseMany<SkillName> SkillProficiencies { get; init; }
    public ChooseMany<Instrument> InstrumentProfieciencies { get; init; }
    public ChooseMany<Feat> Feats { get; init; }
}