using DndHelper.Domain.Dnd;

namespace DndHelper.App.ApplicationClasses
{
    public interface ICreatesCharacter
    {
        void SubscribeToModel<TModel>() where TModel : BindableObject;
        bool CanCreate();
        public Character Create();
    }
}
