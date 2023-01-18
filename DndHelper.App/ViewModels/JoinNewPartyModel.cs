using DndHelper.App.Authentication;
using System.ComponentModel;
using DndHelper.Infrastructure;

namespace DndHelper.App.ViewModels
{
    public class JoinNewPartyModel : INotifyPropertyChanged
    {
        private IAuthenticationProvider<string> authProvider;
        private string id;

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
