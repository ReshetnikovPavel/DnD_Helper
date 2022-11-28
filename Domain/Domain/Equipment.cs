using Infrastructure;

namespace Domain;

public class Equipment : ValueType<Equipment>, IDndObject
{
    public Equipment(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public string Description { get; }
}