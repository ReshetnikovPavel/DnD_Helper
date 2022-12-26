using Infrastructure;

namespace Domain;

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
	public string Name { get; }
	
	public Dice Damage { get; set; }

	public string DamageType { get; set; }
}