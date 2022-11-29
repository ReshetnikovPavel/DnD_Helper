using Infrastructure;

namespace Domain;

public class Character : IDndObject
{
	public Character()
    {
        ProficiencyBonus = new ProficiencyBonus(2);
        Abilities = AbilityScore.Create();
        Skills = Skill.CreateFrom(Abilities, ProficiencyBonus);
        Speed = new Speed(0);
        SavingThrows = SavingThrow.CreateFrom(Abilities, ProficiencyBonus);
    }
	
	public string Name { get; }
	//public string PlayerName { get; }
    public IReadOnlyDictionary<AbilityName, AbilityScore> Abilities { get; }
    public IReadOnlyDictionary<AbilityName, SavingThrow> SavingThrows { get; }
    public IReadOnlyDictionary<SkillName, Skill> Skills { get; }
    public Race Race { get; set; }
	public Class Class { get; set;  }
	public Background Background { get; set; }
	public ProficiencyBonus ProficiencyBonus { get; }
    public Size Size { get; set; }
    public Speed Speed { get; set; }
    public HashSet<Language> Languages { get; set; } = new();
    public HashSet<Weapon> WeaponsProficiencies { get; set; } = new();
    public HashSet<Instrument> InstrumentProficiencies { get; set; } = new();
    public List<Equipment> Equipment { get; set; } = new();

    public List<Weapon> Weapons { get; set; } = new();
    public List<Instrument> Instruments { get; set; } = new();
    public HashSet<Feat> Feats { get; set; } = new();
    public HashSet<Trait> Traits { get; set; } = new();
    public HashSet<Spell> Spells { get; set; } = new();
    public AbilityName? SpellAbility { get; set; }

    public SpellSlotsTable SpellSlotsTable { get; set; }

    public HitDice HitDice { get; set; }

    public void ApplyRace()
	{
        foreach (var bonus in Race.AbilityScoreBonuses)
            Abilities[bonus.Name].AddBonus(bonus);

        Speed.Add(Race.Speed);

        Size = Race.Size;

        Languages.UnionWith(Race.Languages);

        foreach (var (level, spell) in Race.Spells)
            if (level == 1)
                Spells.Add(spell);

        WeaponsProficiencies.UnionWith(Race.WeaponsProficiencies);

        Feats.UnionWith(Race.Feats);
        
        Traits.UnionWith(Race.Traits);

        InstrumentProficiencies.UnionWith(Race.InstrumentProfieciencies);

        foreach (var skillName in Race.SkillProficiencies) 
            Skills[skillName].IsProficient = true;
    }

    public void ApplyBackground()
    {
        Equipment.AddRange(Background.Equipment);

        InstrumentProficiencies.UnionWith(Background.InstrumentProficiencies);

        foreach (var skillName in Background.SkillProficiencies)
            Skills[skillName].IsProficient = true;

        Instruments.AddRange(Background.InstrumentProficiencies);
    }

    public void ApplyClass()
    {
        HitDice = Class.HitDice;

        foreach (var abilityName in Class.AbilityNamesForSavingThrows) 
            SavingThrows[abilityName].IsProficient = true;

        SpellAbility = Class.SpellAbility;
        
        SpellSlotsTable = Class.SpellSlotsTable;

        Class.SpellSlotsTable = SpellSlotsTable;

        foreach (var (level, features) in Class.LevelFeatures)
        foreach (var feature in features)
            if (level == 1)
                ApplyFeature(feature);
    }

    private void ApplyFeature(ClassFeature feature)
    {
        Weapons.AddRange(feature.Weapons);
        Instruments.AddRange( feature.Instruments);
    }
}