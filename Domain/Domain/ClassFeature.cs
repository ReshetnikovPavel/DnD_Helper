using Infrastructure;

namespace Domain;

public class ClassFeature : ValueType<ClassFeature>, IDndObject
{
    public string Name { get; set; }
    public Armor PosessionArmor { get; set; }
    public Weapon PosessionWeapon { get; set; }
    public Skill Proficiency { get; set; }

}