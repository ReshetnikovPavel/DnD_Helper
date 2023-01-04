using DndHelper.App.Authentication;
using System.ComponentModel;

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
            var result = await authProvider.SignInWithEmailAndPassword(UserName, UserPassword);
            if (result.IsSuccess)
                await Shell.Current.GoToAsync(nameof(MenuModel));
            else
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
