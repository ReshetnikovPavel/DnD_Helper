using System.Text.Json.Serialization;
using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Weapon : ValueType<Weapon>, IDndObject
{
    public Weapon(string name, Dice damage, string damageType)
    {
        Name = name;
        Damage = damage;
        DamageType = damageType;
    }
    public Weapon(string name)
    {
        Name = name;
        Damage = new Dice(1, DiceName.D4);
        DamageType = "Bludgeoning";
    }

    public Weapon()
    {

    }

    public string Name { get; set; }

    public Dice Damage { get; set; }

    public string DamageType { get; set; }
}