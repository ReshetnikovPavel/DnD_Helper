namespace Domain.Repositories;

public class XmlWeaponRepository : XmlRepository, IWeaponRepository
{
    public XmlWeaponRepository() : base("Weapons", "weapon")
    {
    }


}