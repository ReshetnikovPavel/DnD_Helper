using System.ComponentModel;
using DndHelper.Infrastructure;
using System.Net;
using System.Windows.Input;
using DndHelper.App.RouteNavigation;
using DndHelper.Domain.Campaign;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Infrastructure.Authentication;

namespace DndHelper.App.ViewModels
{
    public class JoinNewPartyModel : INotifyPropertyChanged
    {
        private readonly ICampaignFactory<Guid, HttpStatusCode> campaignFactory;

        public JoinNewPartyModel(ICampaignFactory<Guid, HttpStatusCode> campaignFactory, ICharacterRepository<HttpStatusCode> characterRepository)
        {
            this.campaignFactory = campaignFactory;
            this.characterRepository = characterRepository;
        }
        private readonly ICharacterRepository<HttpStatusCode> characterRepository;
        
        private string id;
        public IEnumerable<Character> Characters { get; set; }
        public ICommand SelectCharacter { get; }


        public event PropertyChangedEventHandler PropertyChanged;

        public string Id
        {
            get => id; set
            {
                id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public ICommand JoinNewParty => new Command(OnJoinNewParty);

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public void OnJoinNewParty()
        {
            
        }

        public async void LoadCharacterNames()
        {
            (await characterRepository.GetCharacters())
                .OnSuccess(characters => LoadCharacterNames(characters))
                .OnFailure(DisplayCannotLoadCharactersAlert);
        }

        private void LoadCharacterNames(IEnumerable<Character> characters)
        {
            Characters = characters;
        }

        private static async void DisplayCannotLoadCharactersAlert(INoValueResult<HttpStatusCode> result)
        {
            await Shell.Current.DisplayAlert("Ќе удалось загрузить персонажей", result.Status.ToString(), "Ёх");
        }
    }
}
