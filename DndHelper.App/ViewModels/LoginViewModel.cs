using DndHelper.App.Authentication;
using System.ComponentModel;
using DndHelper.Infrastructure;

namespace DndHelper.App.ViewModels
{
    public class LoginViewModel : BindableObject
    {
        private string userName;
        private string userPassword;
        private readonly IAuthenticationProvider<string> authProvider;


        public event PropertyChangedEventHandler PropertyChanged;

        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }

        public string UserName
        {
            get => userName; set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string UserPassword
        {
            get => userPassword; set
            {
                userPassword = value;
                RaisePropertyChanged("UserPassword");
            }
        }

        public LoginViewModel(IAuthenticationProvider<string> authProvider)
        {
            this.authProvider = authProvider;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }

        private async void LoginBtnTappedAsync(object obj)
        {
            (await authProvider.SignInWithEmailAndPassword(UserName, UserPassword))
                .OnSuccess(GoToMenuPage)
                .OnFailure(DisplayLogInAlert);
        }


        private static async void GoToMenuPage()
        {
            await Shell.Current.GoToAsync(nameof(MenuModel));
        }
        private static async void DisplayLogInAlert(Result<User<string>, AuthenticationStatus> result)
        {
            await Shell.Current.DisplayAlert("Не удалось войти", result.Status.ToString(), "Эх");
        }

        private static async void RegisterBtnTappedAsync(object obj)
        {
            await Shell.Current.GoToAsync(nameof(RegisterViewModel));
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
