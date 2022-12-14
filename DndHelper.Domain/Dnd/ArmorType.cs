using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class ArmorType : ValueType<ArmorType>, IDndObject
{
    public ArmorType(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}