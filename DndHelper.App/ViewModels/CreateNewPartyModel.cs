using System.ComponentModel;
using System.Net;
using System.Windows.Input;
using DndHelper.Domain.Campaign;
using DndHelper.Infrastructure;
using DndHelper.Infrastructure.Authentication;

namespace DndHelper.App.ViewModels
{
    public class CreateNewPartyModel : INotifyPropertyChanged
    {
        private readonly ICampaignFactory<Guid, HttpStatusCode> campaignFactory;
        private readonly IAuthenticationProvider<string> authenticationProvider;

        public CreateNewPartyModel(ICampaignFactory<Guid, HttpStatusCode> campaignFactory, IAuthenticationProvider<string> authenticationProvider)
        {
            this.campaignFactory = campaignFactory;
            this.authenticationProvider = authenticationProvider;
        }

        private IAuthenticationProvider<string> authProvider;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => name; set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public ICommand CreateNewParty => new Command(OnCreateNewParty);

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private async void OnCreateNewParty()
        {
            var gameMaster = new GameMaster(authenticationProvider.User.Id);
            var result = (await campaignFactory.CreateNew(Name, gameMaster))
                .OnSuccess(GoToPartyPage)
                .OnFailure(DisplayCannotCreatePartyAlert);

        }

        private static void GoToPartyPage()
        {
            //TODO
        }

        private static async void DisplayCannotCreatePartyAlert(Result<ICampaign<Guid, HttpStatusCode>, HttpStatusCode> result)
        {
            await Shell.Current.DisplayAlert("Ќе удалось создать партию", result.Status.ToString(), "Ёх");
        }
    }
}
