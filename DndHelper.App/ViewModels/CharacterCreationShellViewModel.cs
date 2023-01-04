using DndHelper.App.ApplicationClasses;
using DndHelper.App.RouteNavigation;
using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class CharacterCreationShellViewModel : BindableObject
    {
        public ICommand GoToCharacterSheet { get; }
        private readonly ICreatesCharacter creator;
        private readonly CharacterCreationNavigator characterCreationNavigator;

        public CharacterCreationShellViewModel(ICreatesCharacter creator, CharacterCreationNavigator characterCreationNavigator)
        {
            this.creator = creator;
            this.characterCreationNavigator = characterCreationNavigator;
            GoToCharacterSheet = new Command(characterCreationNavigator.TryGoToCharacterSheet);
            AddModels();
        }

        private void AddModels()
        {
            AddModel<RaceSelectionModel>();
            AddModel<ClassSelectionModel>();
            AddModel<AbilityScoreSelectionModel>();
            AddModel<BackgroundSelectionModel>();
        }

        private void AddModel<TModel>() where TModel : BindableObject
        {
            characterCreationNavigator.AddModel<TModel>();
        }
    }
}
