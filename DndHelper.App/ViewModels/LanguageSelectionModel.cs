using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class LanguageSelectionModel : BindableObject
    {
        public ICommand SelectLanguages { get; set;} 

        public int NumberOfLanguages => 2;

        public string[] Languages
            => new string[] { "Язык булочек", "Вой батарей", "Мяукание Джемки" };
    }
}
