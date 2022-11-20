using Infrastructure;

namespace Domain;

public class Race : ValueType<Race>
{
	public string Name { get; init; }
    public string SubraceName { get; init; }
    public string Description { get; init; }
	public Size Size { get; init; }
	public Speed Speed { get; init; }
	public AbilityScoreBonus[] AbilityScoreBonuses { get; init; }
	public Language[] Languages { get; init; }
	public Spell[] Spells { get; init; }
	public Weapon[] WeaponsProficiencies { get; init; }
	public SkillName[] SkillProficiencies { get; init; }
	public Trait[] Traits { get; init; }
	public Instrument[] InstrumentProfieciencies { get; init; }
	public Feat[] Feats { get; init; }
}