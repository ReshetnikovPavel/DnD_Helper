using System.Windows.Input;
using DndHelper.App.RouteNavigation;
using DndHelper.Domain.Repositories;

namespace DndHelper.App.ViewModels
{
    public class CharacterSelectionModel : BindableObject
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IShellNavigator shellNavigator;
        public ICommand SelectCharacter { get; }
        public ICommand CreateNewCharacter => new Command(OnCreateNewCharacter);

        public string[] CharacterNames
            => new string[] { "Люля", "Пельмешек", "Поль Реш", "Синий", "Симонов" };

        public CharacterSelectionModel(ICharacterRepository characterRepository, IShellNavigator shellNavigator)
        {
            this.characterRepository = characterRepository;
            this.shellNavigator = shellNavigator;
        }

        private void OnCreateNewCharacter()
        {
            shellNavigator.GoToCharacterCreation();
        }
    }
}
