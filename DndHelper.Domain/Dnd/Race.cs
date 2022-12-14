using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Race : ValueType<Race>, IDndObject
{
	public string Name { get; set; }
    public string SubraceName { get; set; }
    public string Description { get; set; }
	public Size Size { get; set; }
	public Speed Speed { get; set; }
	public IEnumerable<AbilityScoreBonus> AbilityScoreBonuses { get; set; }
	public IEnumerable<Language> Languages { get; set; }
	public IEnumerable<(int level, Spell spells)> Spells { get; set; }
	public IEnumerable<Weapon> WeaponsProficiencies { get; set; }
	public IEnumerable<SkillName> SkillProficiencies { get; set; }
	public IEnumerable<Trait> Traits { get; set; }
	public IEnumerable<Instrument> InstrumentProfieciencies { get; set; }
	public IEnumerable<Feat> Feats { get; set; }
	public RaceOptionals Optionals { get; set; }
}