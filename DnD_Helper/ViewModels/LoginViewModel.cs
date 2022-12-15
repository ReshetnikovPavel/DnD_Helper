using System.ComponentModel;
using DndHelper.App.Authentication;

namespace DnD_Helper.ViewModels
{
    public class LoginViewModel : BindableObject
    {
        private string userName;
        private string userPassword;
        private IAuthenticationProvider<string> authProvider;
        

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

        public LoginViewModel(IAuthenticationProvider<string> authProvider)//, RegisterPage registerPage)
        {
            this.authProvider = authProvider;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }

        private async void LoginBtnTappedAsync(object obj)
        {
            await authProvider.SignInWithEmailAndPassword(UserName, UserPassword);
            //await Shell.Current.GoToAsync(nameof(MainMenuPage));
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await Shell.Current.GoToAsync(nameof(RegisterViewModel));
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
