using System.ComponentModel;
using Infrastructure;

namespace DnD_Helper.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private string userName;
        private string userPassword;
        private IAuthProvider authProvider;
        

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

        public LoginViewModel(INavigation navigation, IAuthProvider authProvider)
        {
            this._navigation = navigation;
            this.authProvider = authProvider;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }

        private async void LoginBtnTappedAsync(object obj)
        {
            await authProvider.SignInWithEmailAndPassword(UserName, UserPassword);
            //TODO: await this._navigation.PushAsync();
            throw new NotImplementedException("Нужно следующую страницу привязать");
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new RegisterPage());
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
