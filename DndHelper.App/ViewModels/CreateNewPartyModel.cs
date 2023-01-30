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
        private readonly IUserProvider<string> userProvider;

        public CreateNewPartyModel(ICampaignFactory<Guid, HttpStatusCode> campaignFactory, IUserProvider<string> userProvider)
        {
            this.campaignFactory = campaignFactory;
            this.userProvider = userProvider;
        }
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
            var user = userProvider.User;
            var gameMaster = new GameMaster(user.Id);
            var result = (await campaignFactory.CreateNew(Name, gameMaster))
                .OnSuccess(GoToPartyPage)
                .OnFailure(DisplayCannotCreatePartyAlert);

        }

        private static void GoToPartyPage()
        {
            //TODO
        }

        private static async void DisplayCannotCreatePartyAlert(Result<ICampaign, HttpStatusCode> result)
        {
            await Shell.Current.DisplayAlert("�� ������� ������� ������", result.Status.ToString(), "��");
        }
    }
}
