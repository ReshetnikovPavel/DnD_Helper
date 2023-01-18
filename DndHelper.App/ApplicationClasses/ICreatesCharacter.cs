using DndHelper.Domain.Dnd;

namespace DndHelper.App.ApplicationClasses
{
    public interface ICreatesCharacter
    {
        bool CanCreate();
        bool MustSelect(string attribute);
        void AddAttribute(string attribute, Func<bool> canSelect);
        public Character Create();
    }
}
