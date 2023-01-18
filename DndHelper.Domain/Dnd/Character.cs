using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Character : Entity<Guid>, IDndObject
{
    public Character(Abilities abilities) : base(Guid.NewGuid())
    {
        ProficiencyBonus = new ProficiencyBonus(2);
        Speed = new Speed(0);
        Abilities = abilities;
        Skills = Skills.Create(abilities, ProficiencyBonus);
        SavingThrows = SavingThrows.Create(abilities, ProficiencyBonus);
    }

	public string Name { get; set; }
    public Abilities Abilities { get;  }
    public SavingThrows SavingThrows { get; }
    public Skills Skills { get; }
    public Race Race { get; private set; }
	public Class Class { get; private set;  }
	public Background Background { get; private set; }
	public ProficiencyBonus ProficiencyBonus { get; }
    public Size Size { get; private set; }
    public Speed Speed { get; private set; }
    public HashSet<Language> Languages { get; private set; } = new();
    public HashSet<Weapon> WeaponsProficiencies { get; private set; } = new();
    public HashSet<Instrument> InstrumentProficiencies { get; private set; } = new();
    public List<Equipment> Equipment { get; private set; } = new();

    public List<Weapon> Weapons { get; private set; } = new();
    public List<Instrument> Instruments { get; private set; } = new();
    public HashSet<Feat> Feats { get; private set; } = new();
    public HashSet<Trait> Traits { get; private set; } = new();
    public HashSet<Spell> Spells { get; private set; } = new();
    public AbilityName? SpellAbility { get; private set; }
    public int Initiative => Abilities.Dexterity.Modifier;
    public int AC => 10;

    public SpellSlotsTable SpellSlotsTable { get; private set; }

    public HitDice HitDice { get; private set; }
    public HitPoints HitPoints { get; private set; }

    public void ApplyRace(Race race)
	{
        Race = race;

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

    public void ApplyBackground(Background background)
    {
        Background = background;

        Equipment.AddRange(Background.Equipment);

        InstrumentProficiencies.UnionWith(Background.InstrumentProficiencies);

        foreach (var skillName in Background.SkillProficiencies)
            Skills[skillName].IsProficient = true;

        Instruments.AddRange(Background.InstrumentProficiencies);
    }

    public void ApplyClass(Class dndClass)
    {
        Class = dndClass;

        HitDice = Class.HitDice;

        foreach (var abilityName in Class.AbilityNamesForSavingThrows)
            SavingThrows[abilityName].IsProficient = true;

        SpellAbility = Class.SpellAbility;

        SpellSlotsTable = Class.SpellSlotsTable;

        Class.SpellSlotsTable = SpellSlotsTable;

        for (var index = 0; index < Class.LevelFeatures.Count; index++)
        {
            var level = index + 1;
            var features = Class.LevelFeatures[index];
            foreach (var feature in features)
                if (level == 1)
                    ApplyFeature(feature);
        }
    }

    private void ApplyFeature(ClassFeature feature)
    {
        Weapons.AddRange(feature.Weapons);
        Instruments.AddRange(feature.Instruments);
    }
}
