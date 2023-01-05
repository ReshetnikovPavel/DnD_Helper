using System.Net;
using System.Windows.Input;
using DndHelper.App.RouteNavigation;
using DndHelper.Domain.Repositories;

namespace DndHelper.App.ViewModels
{
    public class CharacterSelectionModel : BindableObject
    {
        private readonly ICharacterRepository<HttpStatusCode> characterRepository;
        private readonly IShellNavigator shellNavigator;
        public ICommand SelectCharacter { get; }
        public ICommand CreateNewCharacter => new Command(OnCreateNewCharacter);

        public IEnumerable<string> CharacterNames { get; private set; }

        private string[] mockNames = { "Люля", "Пельмешек", "Поль Реш", "Синий", "Симонов" };

        public CharacterSelectionModel(ICharacterRepository<HttpStatusCode> characterRepository, IShellNavigator shellNavigator)
        {
            this.characterRepository = characterRepository;
            this.shellNavigator = shellNavigator;
        }

        private void OnCreateNewCharacter()
        {
            shellNavigator.GoToCharacterCreation();
        }

        public async void LoadCharacterNames()
        {
            var result = await characterRepository.GetCharacters();

        }
    }
}
