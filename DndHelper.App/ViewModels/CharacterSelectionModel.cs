using System.Net;
using System.Windows.Input;
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
        public ICommand SelectCharacter => new Command<Character>(GoToCharacterSheet);
        public ICommand CreateNewCharacter => new Command(OnCreateNewCharacter);
        
        private IEnumerable<Character> characters;
        public IEnumerable<Character> Characters
        {
            get => characters;
            set
            {
                characters = value;
                OnPropertyChanged();
            }
        }

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

        public async void GoToCharacterSheet(Character character)
        {
            await Shell.Current.GoToAsync($"/{nameof(CharacterSheetViewModel)}",
                new Dictionary<string, object>
                {
                    ["Character"] = character
                }
            );
        }

        public async void LoadCharacterNames()
        {
            (await characterRepository.GetCharacters())
                .OnSuccess(result => LoadCharacterNames(result.Value))
                .OnFailure(DisplayCannotLoadCharactersAlert);
        }

        private void LoadCharacterNames(IEnumerable<Character> characters)
        {
            Characters = characters;
        }

        private static async void DisplayCannotLoadCharactersAlert(INoValueResult<HttpStatusCode> result)
        {
            await Shell.Current.DisplayAlert("Не удалось загрузить персонажей", result.Status.ToString(), "Эх");
        }
    }
}
