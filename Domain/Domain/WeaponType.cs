using Infrastructure;

namespace Domain;

public class WeaponType : ValueType<WeaponType>, IDndObject
{
    public string Name { get; set; }
}