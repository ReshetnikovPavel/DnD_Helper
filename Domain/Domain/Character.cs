using Infrastructure;

namespace Domain;

public class Character : Entity<Guid>, IDndObject
{
	public Character(Guid id) : base(id)
	{
        Abilities = AbilityScore.Create();
        Skills = Skill.CreateFrom(Abilities);
        Speed = new Speed(0);
        ProficiencyBonus = new ProficiencyBonus(2);
    }
	
	public string Name { get; }
	//public string PlayerName { get; }
    public IReadOnlyDictionary<AbilityName, AbilityScore> Abilities { get; }
	public Race Race { get; set; }
	public Class Class { get; }
	public Background Background { get; set; }
	public IReadOnlyDictionary<SkillName, Skill> Skills { get; }
	public ProficiencyBonus ProficiencyBonus { get; }
    public Size Size { get; set; }
    public Speed Speed { get; set; }
    public HashSet<Language> Languages { get; set; } = new();
    public HashSet<Weapon> WeaponsProficiencies { get; set; } = new();
    public HashSet<Instrument> InstrumentProficiencies { get; set; } = new();
    public HashSet<Feat> Feats { get; set; } = new();
    public HashSet<Trait> Traits { get; set; } = new();
    public HashSet<Spell> Spells { get; set; } = new();
    


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
}