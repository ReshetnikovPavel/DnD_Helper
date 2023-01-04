using System.Windows.Input;
using DndHelper.App.Authentication;
using DndHelper.App.RouteNavigation;
using DndHelper.App.ViewModels;

namespace DndHelper.App.ViewModels
{
    public class MenuModel : BindableObject
    {
        public ICommand SelectMyCharacter => new Command(OnSelectMyCharacter);
        public ICommand CreateNewCharacter => new Command(OnCreateMyCharacter);
        public ICommand SelectMyParty => new Command(OnSelectMyParty);
        private readonly IShellNavigator mainNavigator;
        private readonly IAuthenticationProvider<string> authenticationProvider;

        public MenuModel(IShellNavigator mainNavigator, IAuthenticationProvider<string> authenticationProvider)
        {
            this.mainNavigator = mainNavigator;
            this.authenticationProvider = authenticationProvider;
        }

        private void OnCreateMyCharacter()
        {
            CheckAuthentication(mainNavigator.GoToCharacterCreation);
        }

        private void OnSelectMyCharacter()
        {
            CheckAuthentication(() => Shell.Current.GoToAsync(nameof(CharacterSelectionModel)));
        }

        private void OnSelectMyParty()
        {
            CheckAuthentication(() => Shell.Current.GoToAsync(nameof(PartySelectionModel)));
        }

        private void CheckAuthentication(Action goToPage)
        {
            if (authenticationProvider.IsAuthenticated)
                goToPage();
            else
                Shell.Current.GoToAsync(nameof(LoginViewModel));
        }
    }
}
