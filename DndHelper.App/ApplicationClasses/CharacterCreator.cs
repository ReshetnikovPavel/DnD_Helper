using DndHelper.Domain.Dnd;

namespace DndHelper.App.ApplicationClasses
{
    public class CharacterCreator : ICreatesCharacter
    {
        private IStateManager<string, object> stateManager;

        public CharacterCreator(IStateManager<string, object> stateManager)
        {
            this.stateManager = stateManager;
        }

        public void SubscribeToModel<TModel>() where TModel : BindableObject
        {
            MessagingCenter.Subscribe<TModel, Selection>(
                this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        }

        public bool CanCreate()
        {
            return true;
        }

        public Character Create()
        {
            return null;
        }

        private void OnSelectionMade(object sender, Selection selection)
        {
            stateManager.SetValue(selection.Property, selection.Value);
        }
    }
}

