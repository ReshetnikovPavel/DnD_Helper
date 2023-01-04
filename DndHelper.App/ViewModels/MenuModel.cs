using System.Windows.Input;
using DndHelper.App.RouteNavigation;

namespace DndHelper.App.ViewModels
{
    public class MenuModel : BindableObject
    {
        public ICommand SelectMyCharacter { get; }
        public ICommand CreateNewCharacter => new Command(OnCreateMyCharacter);
        public ICommand SelectMyParty { get; }
        private readonly IShellNavigator mainNavigator;

        public MenuModel(IShellNavigator mainNavigator)
        {
            this.mainNavigator = mainNavigator;
        }

        private void OnCreateMyCharacter()
        {
            mainNavigator.GoToCharacterCreation();
        }
    }
}
