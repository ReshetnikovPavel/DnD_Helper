using System.Net;
using System.Windows.Input;
using DndHelper.Infrastructure.Authentication;
using DndHelper.App.RouteNavigation;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Infrastructure;
using DndHelper.Domain.Campaign;
using System.Diagnostics;

namespace DndHelper.App.ViewModels
{
    [QueryProperty(nameof(PartyId), nameof(PartyId))]
    public partial class ModelParty : BindableObject
    {
        private Guid partyId;

        public Guid PartyId
        {
            get => partyId;
            set
            {
                partyId = value;
                OnPropertyChanged();
                UpdateParty();
            }
        }

        private ICampaign party;

        public ICampaign Party
        {
            get => party;
            set
            {
                party = value;
                OnPropertyChanged();
            }
        }

        private readonly ICampaignFactory<Guid, HttpStatusCode> campaignFactory;

        public ModelParty(ICampaignFactory<Guid, HttpStatusCode> campaignFactory)
        {
            this.campaignFactory = campaignFactory;

        }

        public ICommand OpenCharacter { get; }

        public string IdDisplay => Party?.Id.ToString();
        public string Test => "AHHHHHHHH, pain :)";

        private void UpdateParty()
        {
            Party = campaignFactory.GetExisting(PartyId).Result.Value;
        }
    }
}
