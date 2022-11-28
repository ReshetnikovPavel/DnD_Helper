using Infrastructure;

namespace Domain;

public class ArmorType : ValueType<ArmorType>, IDndObject
{
    public ArmorType(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}