using DndHelper.Domain.Dnd;

namespace DndHelper.App.ApplicationClasses
{
    public enum CharacterAttributes
    {
        Race,
        Subrace,
        RaceAbilityBonus,
        Languages,
        Class,
        Subclass,
        Spells,
        Skills,
        Abilities,
        Name,
        Background,
        ToolProficiencies,
        Equipment
    };

    public interface ICreatesCharacter
    {
        bool CanCreate();
        bool CanSelect(CharacterAttributes attribute);
        public Character Create();
    }
}
