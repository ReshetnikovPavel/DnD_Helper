using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class MenuModel : BindableObject
    {
        public ICommand SelectMyCharacter { get; }
        public ICommand CreateNewCharacter { get; }
        public ICommand SelectMyParty { get; }
    }
}
