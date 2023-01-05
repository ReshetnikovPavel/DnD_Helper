using System.Net;
using System.Windows.Input;
using DndHelper.App.Authentication;
using DndHelper.App.RouteNavigation;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Infrastructure;

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
            (await characterRepository.GetCharacters())
                .OnSuccess(result => LoadCharacterNames(result.Value))
                .OnFailure(DisplayCannotLoadCharactersAlert);
        }

        private void LoadCharacterNames(IEnumerable<Character> characters)
        {
            CharacterNames = characters.Select(c => c.Name);
        }

        private static async void DisplayCannotLoadCharactersAlert(INoValueResult<HttpStatusCode> result)
        {
            await Shell.Current.DisplayAlert("Не удалось загрузить персонажей", result.Status.ToString(), "Эх");
        }
    }
}
