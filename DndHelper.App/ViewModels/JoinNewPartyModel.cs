using System.ComponentModel;
using DndHelper.Infrastructure;
using System.Net;
using System.Windows.Input;
using DndHelper.App.RouteNavigation;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Infrastructure.Authentication;

namespace DndHelper.App.ViewModels
{
    public class JoinNewPartyModel : INotifyPropertyChanged
    {
        private readonly ICharacterRepository<HttpStatusCode> characterRepository;

        public JoinNewPartyModel(ICharacterRepository<HttpStatusCode> characterRepository)
        {
            this.characterRepository = characterRepository;
        }
        private string id;
        public string[] characters => new string[3] { "AA", "aaaa", "AAAAAAAAAA" };
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

        public Command JoinNewParty { get; }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
