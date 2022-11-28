using Infrastructure;

namespace Domain;

public class ClassFeature : ValueType<ClassFeature>, IDndObject
{
    public string Name { get; set; }
    public IEnumerable<ArmorType> Armor { get; set; }
    public IEnumerable<WeaponType> Weapon { get; set; }
    public ChooseMany<SkillName> SkillProficiencies { get; set; }

    public IEnumerable<Instrument> Instruments { get; set; }
    public IEnumerable<Weapon> Weapons { get; set; }
    public string Description { get; set; }

}