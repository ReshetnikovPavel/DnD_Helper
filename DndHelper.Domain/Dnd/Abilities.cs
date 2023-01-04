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

    public Abilities(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Dictionary = new Dictionary<AbilityName, AbilityScore>
        {
            [AbilityName.Strength] = new AbilityScore(AbilityName.Strength, strength),
            [AbilityName.Dexterity] = new AbilityScore(AbilityName.Dexterity, dexterity),
            [AbilityName.Constitution] = new AbilityScore(AbilityName.Constitution, constitution),
            [AbilityName.Intelligence] = new AbilityScore(AbilityName.Intelligence, intelligence),
            [AbilityName.Wisdom] = new AbilityScore(AbilityName.Wisdom, wisdom),
            [AbilityName.Charisma] = new AbilityScore(AbilityName.Charisma, charisma)
        };
    }

    public static Abilities CreateDefault()
    {
        return new Abilities(8, 8, 8, 8, 8, 8);
    }

    public AbilityScore this[AbilityName name]
    {
        get => Dictionary [name];
    }
}