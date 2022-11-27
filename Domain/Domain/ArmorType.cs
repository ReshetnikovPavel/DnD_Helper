using Infrastructure;

namespace Domain;

public class ArmorType : ValueType<ArmorType>, IDndObject
{
    public string Name { get; set; }
}