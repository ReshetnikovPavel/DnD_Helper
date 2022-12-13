using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Abilities : ValueType<Abilities>, IDndObject
{
    public AbilityScore Strength { get; }
    public AbilityScore Dexterity { get; }
    public AbilityScore Constitution { get; }
    public AbilityScore Intelligence { get; }
    public AbilityScore Wisdom { get; }
    public AbilityScore Charisma { get; }

    public Abilities(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Strength = new AbilityScore(AbilityName.Strength, strength);
        Dexterity = new AbilityScore(AbilityName.Dexterity, dexterity);
        Constitution = new AbilityScore(AbilityName.Constitution, constitution);
        Intelligence = new AbilityScore(AbilityName.Intelligence, intelligence);
        Wisdom = new AbilityScore(AbilityName.Wisdom, wisdom);
        Charisma = new AbilityScore(AbilityName.Charisma, charisma);
    }

    public Dictionary<AbilityName, AbilityScore> GetDictionary()
    {
        var dictionary = new Dictionary<AbilityName, AbilityScore>();
        dictionary[AbilityName.Strength] = Strength;
        dictionary[AbilityName.Dexterity] = Dexterity;
        dictionary[AbilityName.Constitution] = Constitution;
        dictionary[AbilityName.Intelligence] = Intelligence;
        dictionary[AbilityName.Wisdom] = Wisdom;
        dictionary[AbilityName.Charisma] = Charisma;
        return dictionary;
    }
}