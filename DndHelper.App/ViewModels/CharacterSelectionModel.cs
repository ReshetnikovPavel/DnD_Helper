using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class CharacterSelectionModel : BindableObject
    {
        public ICommand SelectCharacter { get; }
        public ICommand CreateNewCharacter { get; }

        public string[] CharacterNames
            => new string[] { "Люля", "Пельмешек", "Поль Реш", "Синий", "Симонов" };


    }
}
