using DndHelper.App.Authentication;
using System.ComponentModel;

namespace DndHelper.App.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private IAuthenticationProvider<string> authProvider;
        private string email;
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Password
        {
            get => password; set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public Command RegisterUser { get; }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public RegisterViewModel(IAuthenticationProvider<string> authProvider)
        {
            this.authProvider = authProvider;
            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            await authProvider.RegisterUserWithEmailAndPassword(Email, Password);
        }
    }
}
