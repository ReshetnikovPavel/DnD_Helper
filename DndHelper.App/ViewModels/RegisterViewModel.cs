using DndHelper.App.Authentication;
using System.ComponentModel;
using DndHelper.Infrastructure;

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
                RaisePropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => password; set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
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
            (await authProvider.RegisterUserWithEmailAndPassword(Email, Password))
                .OnSuccess(GoToMenuPage)
                .OnFailure(DisplayRegisterAlert);
        }

        private static async void GoToMenuPage()
        {
            await Shell.Current.GoToAsync(nameof(MenuModel));
        }
        private static async void DisplayRegisterAlert(Result<User<string>, AuthenticationStatus> result)
        {
            await Shell.Current.DisplayAlert("Не удалось зарегистрироваться", result.Status.ToString(), "Эх");
        }
    }
}
