using DndHelper.App.Authentication;
using System.ComponentModel;
using DndHelper.Infrastructure;

namespace DndHelper.App.ViewModels
{
    public class CreateNewPartyModel : INotifyPropertyChanged
    {
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

        public Command CreateNewParty { get; }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
