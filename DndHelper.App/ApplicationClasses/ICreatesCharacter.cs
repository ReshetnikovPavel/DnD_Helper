using DndHelper.Domain.Dnd;

namespace DndHelper.App.ApplicationClasses
{
    public interface ICreatesCharacter
    {
        bool CanCreate();
        public Character Create();
    }
}
