using Infrastructure;

namespace Domain;

public class Character : Entity<Guid>, IDndObject
{
	public Character(Guid id) : base(id)
	{
	}
	
	public string Name { get; }
	//public string PlayerName { get; }
	public IReadOnlyDictionary<AbilityName, AbilityScore> Abilities { get; }
	public Race Race { get; set; }
	public Class Class { get; }
	public Background Background { get; set; }
	public IReadOnlyDictionary<SkillName, Skill> Skills { get; }
	public ProficiencyBonus ProficiencyBonus { get; }

	
	
	public Dictionary<AbilityName, AbilityScore> CreateAbilityScores()
	{
		return Enum.GetValues<AbilityName>()
			.ToDictionary(
				abilityName => abilityName,
				abilityName => new AbilityScore(abilityName, 0));
	}
	
	public Dictionary<SkillName, Skill> CreateSkills()
	{
		return null;
	}

	public Size Size { get; set; }
	public Speed Speed { get; set; }

	public List<AbilityScoreBonus> AbilityScoreBonuses { get; set; }
	public List<Language> Languages { get; set; }

	public List<Weapon> WeaponsProficiencies { get; set; }
	public List<SkillName> SkillProficiencies { get; set; }
	public List<Instrument> InstrumentProficiencies { get; set; }
	public List<Feat> Feats { get; set; }
	public List<Trait> Traits { get; set; }
	public List<(int level, Spell spells)> Spells { get; set; }
	//public RaceOptionals Optionals { get; set; }


	public void AplayRace()
	{
		Size = Race.Size;
		Speed = Race.Speed;
		AbilityScoreBonuses.AddRange(Race.AbilityScoreBonuses);
		Languages.AddRange(Race.Languages);
		WeaponsProficiencies.AddRange(Race.WeaponsProficiencies);
		SkillProficiencies.AddRange(Race.SkillProficiencies);
		InstrumentProficiencies.AddRange(Race.InstrumentProfieciencies);
		Feats.AddRange(Race.Feats);
		Traits.AddRange(Race.Traits);
		Spells.AddRange(Race.Spells);
	}

	public void AplayClass()
	{
	}

	public int Money { get; set; }
	public List<Equipment> Equipment { get; set; }
	public List<Instrument> Instruments { get; set; }

	public void AplayBackground()
	{
		Money = Background.money;
		InstrumentProficiencies.AddRange(Background.posessionInstrument);
		Equipment.AddRange(Background.equipment);
		//Skill
		Instruments.AddRange(Background.instrument);
	}
}