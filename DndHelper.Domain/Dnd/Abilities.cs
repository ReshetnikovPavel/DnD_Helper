using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Abilities : ValueType<Abilities>, IDndObject
{
    public Dictionary<AbilityName, AbilityScore> Dictionary { get; }
    public AbilityScore Strength { get => Dictionary[AbilityName.Strength]; }
    public AbilityScore Dexterity { get => Dictionary[AbilityName.Dexterity]; }
    public AbilityScore Constitution { get => Dictionary[AbilityName.Constitution]; }
    public AbilityScore Intelligence { get => Dictionary[AbilityName.Intelligence]; }
    public AbilityScore Wisdom { get => Dictionary[AbilityName.Wisdom]; }
    public AbilityScore Charisma { get => Dictionary[AbilityName.Charisma]; }

    public Abilities(AbilityScore strength, AbilityScore dexterity, AbilityScore constitution, AbilityScore intelligence, AbilityScore wisdom, AbilityScore charisma)
    {
        Dictionary = new Dictionary<AbilityName, AbilityScore>
        {
            [AbilityName.Strength] = strength,
            [AbilityName.Dexterity] = dexterity,
            [AbilityName.Constitution] = constitution,
            [AbilityName.Intelligence] = intelligence,
            [AbilityName.Wisdom] = wisdom,
            [AbilityName.Charisma] = charisma
        };
    }

    // public Abilities(Dictionary<AbilityName, AbilityScore> dictionary)
    // {
    //     Dictionary = dictionary;
    // }

    public static Abilities CreateDefault()
    {
        return Create(8, 8, 8, 8, 8, 8);
    }

    public static Abilities Create(int strength, int dexterity, int constitution, int intelligence, int wisdom,
        int charisma)
    {
        return new Abilities(
            new AbilityScore(AbilityName.Strength, strength),
            new AbilityScore(AbilityName.Dexterity, dexterity),
            new AbilityScore(AbilityName.Constitution, constitution),
            new AbilityScore(AbilityName.Intelligence, intelligence),
            new AbilityScore(AbilityName.Wisdom, wisdom),
            new AbilityScore(AbilityName.Charisma, charisma));
    }

    public AbilityScore this[AbilityName name]
    {
        get => Dictionary [name];
    }
}