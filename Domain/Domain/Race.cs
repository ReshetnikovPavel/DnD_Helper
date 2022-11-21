using Infrastructure;

namespace Domain;

public class Race : ValueType<Race>, IDndObject
{
	public string Name { get; init; }
    public string SubraceName { get; init; }
    public string Description { get; init; }
	public Size Size { get; init; }
	public Speed Speed { get; init; }
	public IEnumerable<AbilityScoreBonus> AbilityScoreBonuses { get; init; }
	public IEnumerable<Language> Languages { get; init; }
	public IEnumerable<Spell> Spells { get; init; }
	public IEnumerable<Weapon> WeaponsProficiencies { get; init; }
	public IEnumerable<SkillName> SkillProficiencies { get; init; }
	public IEnumerable<Trait> Traits { get; init; }
	public IEnumerable<Instrument> InstrumentProfieciencies { get; init; }
	public IEnumerable<Feat> Feats { get; init; }
}