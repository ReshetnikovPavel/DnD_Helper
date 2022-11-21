using Infrastructure;

namespace Domain;

public class RaceOptionals
{
    public Optional<AbilityScoreBonus> AbilityScoreBonuses { get; init; }
    public Optional<Language> Languages { get; init; }
    public Optional<Spell> Spells { get; init; }
    public Optional<Weapon> WeaponsProficiencies { get; init; }
    public Optional<SkillName> SkillProficiencies { get; init; }
    public Optional<Trait> Traits { get; init; }
    public Optional<Instrument> InstrumentProfieciencies { get; init; }
    public Optional<Feat> Feats { get; init; }
}