using System.Collections.ObjectModel;
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
        public ICommand DeleteCharacter => new Command<Character>(OnDeleteCharacter);

        private ObservableCollection<Character> characters;

        public ObservableCollection<Character> Characters
        {
            get => characters;
            set
            {
                characters = value;
                OnPropertyChanged();
            }
        }

        public CharacterSelectionModel(ICharacterRepository<HttpStatusCode> characterRepository,
            IShellNavigator shellNavigator)
        {
            this.characterRepository = characterRepository;
            this.shellNavigator = shellNavigator;
        }

        private void OnCreateNewCharacter()
        {
            shellNavigator.GoToCharacterCreation();
        }

        private async void OnDeleteCharacter(Character selected)
        {
            var wantToDelete = await DoesUserWantToDeleteTheirCharacter(selected);

            if (wantToDelete)
                (await characterRepository.DeleteCharacter(selected))
                    .OnSuccess(() => Characters.Remove(selected))
                    .OnFailure(DisplayCannotDeleteCharacterAlert);
        }

        private static async Task<bool> DoesUserWantToDeleteTheirCharacter(Character selected)
        {
            return await Shell.Current.DisplayAlert(
                "Это действие невозможно обратить!",
                "Вы действительно хотите удалить персонажа?", 
                "Да", "Нет");
        }

        public async void GoToCharacterSheet(Character selected)
        {
            await Shell.Current.GoToAsync($"/{nameof(CharacterSheetViewModel)}",
                new Dictionary<string, object>
                {
                    ["Character"] = selected
                }
            );
        }

        public async void LoadCharacters()
        {
            (await characterRepository.GetCharacters())
                .OnSuccess(characters => LoadCharacters(characters))
                .OnFailure(DisplayCannotLoadCharactersAlert);
        }

        private void LoadCharacters(IEnumerable<Character> characters)
        {
            Characters = new ObservableCollection<Character>(characters);
        }

        private static async void DisplayCannotLoadCharactersAlert(INoValueResult<HttpStatusCode> result)
        {
            await Shell.Current.DisplayAlert("Не удалось загрузить персонажей", result.Status.ToString(), "Эх");
        }

        private static async void DisplayCannotDeleteCharacterAlert(INoValueResult<HttpStatusCode> result)
        {
            await Shell.Current.DisplayAlert("Не удалось удалить персонажа", result.Status.ToString(), "Эх");
        }
    }
}
