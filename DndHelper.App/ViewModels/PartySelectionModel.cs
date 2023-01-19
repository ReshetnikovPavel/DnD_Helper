using System.Net;
using System.Windows.Input;
using DndHelper.Domain.Campaign;

namespace DndHelper.App.ViewModels
{
    public class PartySelectionModel : BindableObject
    {
        private readonly ICampaignFactory<Guid, HttpStatusCode> campaignFactory;

        public PartySelectionModel(ICampaignFactory<Guid, HttpStatusCode> campaignFactory)
        {
            this.campaignFactory = campaignFactory;
        }

        public ICommand SelectMyParty { get; }

        public ICommand SelectMyMasterParty { get; }

        public ICommand CreateNewParty { get; }
        public ICommand JoinNewParty { get; }

        private IEnumerable<ICampaign> myParties;
        public IEnumerable<ICampaign> MyParties
        {
            get => myParties;
            set
            {
                myParties = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<ICampaign> myMasterParties;
        public IEnumerable<ICampaign> MyMasterParties
        {
            get => myMasterParties;
            set
            {
                myMasterParties = value;
                OnPropertyChanged();
            }
        }

        public async void LoadParties()
        {
            if ((await campaignFactory.GetMyCampaignsWhereIAmGameMaster()).TryGetValue(out var campaigns1))
            {
                MyMasterParties = campaigns1;
            };

            if ((await campaignFactory.GetMyCampaignsWhereIAmPlayer()).TryGetValue(out var campaigns2))
            {
                MyMasterParties = campaigns2;
            };
        private async void OnPartySelected(string partyName)
        {
            await Shell.Current.GoToAsync($"/{nameof(ModelParty)}",
                new Dictionary<string, object>
                {
                    ["Party"] = null //TODO: вставить сюда партию
                }
                );
        }
    }
}
