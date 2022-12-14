using Infrastructure;

namespace DndHelper.Domain.Dnd;

public class WeaponType : ValueType<WeaponType>, IDndObject
{
    public WeaponType(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}