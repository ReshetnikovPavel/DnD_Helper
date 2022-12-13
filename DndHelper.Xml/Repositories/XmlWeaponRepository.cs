using DndHelper.Domain.Repositories;

namespace DndHelper.Xml.Repositories;

public class XmlWeaponRepository : XmlRepository, IWeaponRepository
{
    public XmlWeaponRepository() : base("Weapons", "weapon")
    {
    }


}