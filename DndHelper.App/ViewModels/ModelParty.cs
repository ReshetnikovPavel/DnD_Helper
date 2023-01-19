using System.Net;
using System.Windows.Input;
using DndHelper.Infrastructure.Authentication;
using DndHelper.App.RouteNavigation;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Infrastructure;
using DndHelper.Domain.Campaign;

namespace DndHelper.App.ViewModels
{
    [QueryProperty(nameof(Party), nameof(Party))]
    public partial class ModelParty : BindableObject
    {
        private ICampaign<Guid, HttpStatusCode> party;

        public ICampaign<Guid, HttpStatusCode> Party
        {
            get => party;
            set
            {
                party = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IdDisplay));
            }
        }

        public ICommand OpenCharacter {get; }

        public string IdDisplay => Party?.Id.ToString();
    }
}
