using Infrastructure;
using System.ComponentModel;

namespace DnD_Helper.ViewModels
{
    internal class RegisterViewModel : INotifyPropertyChanged
    {
        private INavigation navigation;
        private IAuthProvider authProvider;
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

        public RegisterViewModel(INavigation navigation, IAuthProvider authProvider)
        {
            this.navigation = navigation;
            this.authProvider = authProvider;
            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            await authProvider.CreateUserWithEmailAndPassword(Email, Password);
            await navigation.PopAsync();
        }
    }
}
