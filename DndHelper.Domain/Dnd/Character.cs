using System.Text.Json.Serialization;
using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Character : Entity<Guid>, IDndObject
{
    public static Character CreateNew(Abilities abilities)
    {
        var proficiencyBonus = new ProficiencyBonus(2);
        return new Character(Guid.NewGuid(), null, abilities, SavingThrows.Create(abilities, proficiencyBonus),
            Skills.Create(abilities, proficiencyBonus),
            null, null, null, proficiencyBonus, Size.Medium, new Speed(0), new HashSet<Language>(), 
            new HashSet<Weapon>(), 
            new HashSet<Instrument>(), new List<Equipment>(), new List<Weapon>(), new List<Instrument>(), new HashSet<Feat>(), new HashSet<Trait>(), new HashSet<Spell>(), 
            null, null, null, null);
    }

    public Character(Guid id, string name, Abilities abilities, SavingThrows savingThrows, 
                Skills skills, Race race, Class personClass, Background background, ProficiencyBonus proficiencyBonus, 
                Size size, Speed speed, HashSet<Language> languages, HashSet<Weapon> weaponsProficiencies,
                HashSet<Instrument> instrumentProficiencies, List<Equipment> equipment, List<Weapon> weapons,
                List<Instrument> instruments, HashSet<Feat> feats, HashSet<Trait> traits, HashSet<Spell> spells,
                AbilityName? spellAbility, SpellSlotsTable spellSlotsTable, HitDice hitDice, HitPoints hitPoints) : base(id)
    {
        Name = name;
        Abilities = abilities;
        SavingThrows = savingThrows;
        Skills = skills;
        Race = race;
        Class = personClass;
        Background = background;
        ProficiencyBonus = proficiencyBonus;
        Size = size;
        Speed = speed;
        Languages = languages;
        WeaponsProficiencies = weaponsProficiencies;
        InstrumentProficiencies = instrumentProficiencies;
        Equipment = equipment;
        Weapons = weapons;
        Instruments = instruments;
        Feats = feats;
        Traits = traits;
        Spells = spells;
        SpellAbility = spellAbility;
        SpellSlotsTable = spellSlotsTable;
        HitDice = hitDice;
        HitPoints = hitPoints;
    }


    public string Name { get; set; }
    public Abilities Abilities { get; set; }
    public SavingThrows SavingThrows { get; set; }
    public Skills Skills { get; set; }
    public Race Race { get; private set; }
	public Class Class { get; private set;  }
	public Background Background { get; private set; }
	public ProficiencyBonus ProficiencyBonus { get; set; }
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
