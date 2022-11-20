using Infrastructure;

namespace Domain;

public class Race : ValueType<Race>
{
	public string Name { get; set; }
	public string Description { get; }
	public Size Size { get; }
	public Speed Speed { get; }
	public AbilityScoreBonus[] AbilityScoreBonuses { get; }
	public Language[] Languages { get; }
	public Spell[] Spells { get; }
	public Weapon[] WeaponsProficiencies { get; }
	public SkillName[] SkillProficiencies { get; }
	public Trait[] Traits { get; }
	public Instrument[] InstrumentProfieciencies { get; }
	public Feat[] Feats { get; }
}